using AssessmentWebAPI.Data;
using AssessmentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AssessmentWebAPI.Controllers
{
    public class DeviceController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static AssetRequest GetDeviceIds(DeviceRequest request)
        {
            var obj = new AssetRequest();
            obj.DeviceIds = new List<string>();
            foreach (var device in request.Devices)
            {
                obj.DeviceIds.Add(device.DeviceId);
            }
            return obj;
        }

        //public static List<Device> GetDevices()
        //{
        //    return new List<Device>()
        //    {
        //        new Device()
        //        {
        //            DeviceId = "DVID00000123",
        //            Name = "First Device",
        //            Location = "Melbourne",
        //            Type = "Temperature Sensor"
        //        },
        //        new Device()
        //        {
        //            DeviceId = "DVID00000124",
        //            Name = "Second Device",
        //            Location = "Sydney",
        //            Type = "Pressure Sensor"
        //        },
        //        new Device()
        //        {
        //            DeviceId = "DVID00000125",
        //            Name = "Third Device",
        //            Location = "Brisbane",
        //            Type = "Humidity Sensor"
        //        }
        //    };
        //}

        [HttpPost]
        public bool RegisterDevices(DeviceRequest request)
        {
            var obj = DeviceAssetsController.GetAssetResponse(request);
            
            try
            {
                Database.InsertDevice(obj);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        
    }
}
