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
        /// Extracts DeviceIds from the JSON input to be passed onto the Inventory API. 
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
        /// <summary>
        /// Inserts/Registers records/devices in the database. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
