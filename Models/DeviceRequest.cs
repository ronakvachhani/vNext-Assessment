using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AssessmentWebAPI.Models
{
    [DataContract]
    public class DeviceRequest
    {
        [DataMember]
        public List<Device> Devices { get; set; }

    }
}