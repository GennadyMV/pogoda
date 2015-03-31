using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulletin.Models
{
    public enum Territory {
        Region = 1,
        Locality = 2
    };
    public class RegionTemplate
    {
        public virtual int ID { get; set; }        
        public virtual string Name { get; set; }
        public virtual int Deltawind { get; set; }
        public virtual int Deltatemperature { get; set; }
        public virtual int Territory { get; set; }
    }
}
