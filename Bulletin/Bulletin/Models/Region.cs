using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulletin.Models
{
    public class Region
    {
        public virtual int ID { get; set; }        
        public virtual string Name { get; set; }
        public virtual int Deltawind { get; set; }
        public virtual int Deltatemperature { get; set; }
        public virtual Territory Territory { get; set; }
    }
}
