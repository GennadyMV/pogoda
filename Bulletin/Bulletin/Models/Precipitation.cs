using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Bulletin.Models
{
    // Осадки
    [JsonObject]
    public class Precipitation
    {
        public virtual int ID { get; set; }
        [JsonProperty("Name")]
        public virtual string Name { get; set; }
    }
}