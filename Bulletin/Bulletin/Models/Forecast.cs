using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulletin.Models
{
    public class Forecast
    {
        public virtual int ID { get; set; }
        public virtual int Distance { get; set; } 
        public virtual Bulletin Bulletin { get; set; }
        public virtual Territory Territory { get; set; }
        public virtual Value ValueDay { get; set; }
        public virtual Value ValueNight { get; set; }
    }
}