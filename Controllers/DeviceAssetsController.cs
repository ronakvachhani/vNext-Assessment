using AssessmentWebAPI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;


namespace AssessmentWebAPI.Controllers
{
    public class DeviceAssetsController : ApiController
    {

        public static DeviceRequest GetAssetResponse(DeviceRequest devices)
        {
            AssetRequest assetRequests = DeviceController.GetDeviceIds(devices); 
            
            //Serialize DeviceId list for Inventory API
            var json = JsonConvert.SerializeObject(assetRequests);

            //Create RestClient
            var client = new RestClient("http://tech-assessment.vnext.com.au/api/devices/assetId/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("x-functions-key", "DRefJc8eEDyJzS19qYAKopSyWW8ijoJe8zcFhH5J1lhFtChC56ZOKQ==");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=136db78527ad94c9c44b111bf671d4b0183d9fa7e3f379d4d3855475997ea8ef");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.IsSuccessful)
            {
                AssetResponse deviceResponse = JsonConvert.DeserializeObject<AssetResponse>(response.Content);

                devices = AssignDeviceAssetIds(devices, deviceResponse);
            }

            return devices;
        }

        /// <summary>
        /// Updates the input list to populate the AssetId field using the response from the Inventory API.
        /// </summary>
        /// <param name="devices"></param>
        /// <param name="deviceResponse"></param>
        /// <returns></returns>
        public static DeviceRequest AssignDeviceAssetIds(DeviceRequest devices, AssetResponse deviceResponse)
        {
            if (deviceResponse == null || !deviceResponse.Devices.Any())
                return devices;

            foreach (var x in deviceResponse.Devices)
            {
                //Null condition to handle duplicates i.e. unique AssetIds for the same DeviceId
                var device = devices?.Devices.FirstOrDefault(d => d.DeviceId == x.DeviceId && d.AssetId == null);
                if (device != null)
                    device.AssetId = x.AssetId;
            }

            return devices;
        }


    }
}
