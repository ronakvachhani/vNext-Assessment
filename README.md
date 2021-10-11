# vNext Assessment

This repo includes a .NET Framework Web API project:

## WEB API Details:

The API end-point is hosted on Azure App Service at:
http://vnext-assessment.azurewebsites.net/api/Device/RegisterDevices

and accepts the JSON request as follows:

```json
{
   "devices":[
      {
         "DeviceId":"DVID00000123",
         "Name":"device 1 name",
         "location":"Melbourne",
         "type":"Pressure Sensor"
      },
      {
         "DeviceId":"DVID00000124",
         "Name":"device 2 name",
         "location":"Geelong",
         "type":"Temperature Sensor"
      }
   ]
}
```

This 'RegisterDevices' API will in turn forward the deviceIds (from the JSON request) to the inventory API, fetch the asset ID and insert the records in the Azure SQL database.
