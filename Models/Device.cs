using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AssessmentWebAPI.Models
{
    [DataContract]
    public class Device
    {
        [DataMember]
        public string DeviceId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string AssetId { get; set; }
    }
}