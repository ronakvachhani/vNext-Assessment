using AssessmentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace AssessmentWebAPI.Data
{
    public class Database
    {
        public static void InsertDevice(DeviceRequest request)
        {
            //Create the table
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[5] { new DataColumn("DeviceId", typeof(string)),
                        new DataColumn("Name", typeof(string)),
                        new DataColumn("Location",typeof(string)) ,
                        new DataColumn("Type", typeof(string)) ,
                        new DataColumn("AssetId",typeof(string)) });

            foreach (var device in request.Devices)
            {
                //Populate the table
                table.Rows.Add(device.DeviceId, device.Name, device.Location, device.Type, device.AssetId);
            }

            if (table.Rows.Count > 0)
            {
                string connectionStr = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the table/column mappings
                        sqlBulkCopy.DestinationTableName = "dbo.Device";

                        sqlBulkCopy.ColumnMappings.Add("DeviceId", "DeviceId");
                        sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                        sqlBulkCopy.ColumnMappings.Add("Location", "Location");
                        sqlBulkCopy.ColumnMappings.Add("Type", "Type");
                        sqlBulkCopy.ColumnMappings.Add("AssetId", "AssetId");
                        con.Open();
                        sqlBulkCopy.WriteToServer(table);
                        con.Close();
                    }
                }
            }

        }
    }
}