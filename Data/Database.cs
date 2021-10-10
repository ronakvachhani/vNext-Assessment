using AssessmentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AssessmentWebAPI.Data
{
    public class Database
    {
        public static void InsertDevice(DeviceRequest request)
        {
            foreach (var device in request.Devices)
            {
                using (SqlConnection objConnection = new SqlConnection("Server=tcp:vnext-sql.database.windows.net,1433;Initial Catalog=vnext-devices;Persist Security Info=False;User ID=vnext-sql;Password=eb4uTud8SnuVQet;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    using (SqlCommand objCommand = new SqlCommand("RegisterDevices", objConnection))
                    {
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@DeviceId", device.DeviceId);
                        objCommand.Parameters.AddWithValue("@Name", device.Name);
                        objCommand.Parameters.AddWithValue("@Location", device.Location);
                        objCommand.Parameters.AddWithValue("@Type", device.Type);
                        objCommand.Parameters.AddWithValue("@AssetId", device.AssetId);

                        objConnection.Open();
                        objCommand.ExecuteNonQuery();
                        objConnection.Close();
                    }
                }
            }


        }
    }
}