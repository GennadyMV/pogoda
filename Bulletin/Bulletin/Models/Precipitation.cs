using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulletin.Models
{
    // Осадки
    public class Precipitation
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
    }
}