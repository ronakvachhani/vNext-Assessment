﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AssessmentWebAPI.Models
{
    [DataContract]
    public class DeviceAssets
    {
        [DataMember]
        public string DeviceId { get; set; }
        [DataMember]
        public string AssetId { get; set; }
    }
}