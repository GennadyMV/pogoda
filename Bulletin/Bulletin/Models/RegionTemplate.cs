using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulletin.Models
{
    enum Territory {
        Region = 1,
        Locality = 2
    };
    public class RegionTemplate
    {
        public virtual int ID { get; set; }        
        public virtual string Name { get; set; }
        public virtual string Deltawind { get; set; }
        public virtual string Deltatemperature { get; set; }
        public virtual int Territory { get; set; }
    }
}
