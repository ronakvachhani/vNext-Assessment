using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AssessmentWebAPI.Models
{
    [DataContract]
    public class AssetRequest
    {
        [DataMember]
        public List<string> DeviceIds { get; set; }

    }
}