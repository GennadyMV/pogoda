using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulletin.Models
{
    public class Value
    {
        public virtual int ID { get; set; }

        public virtual Cloudiness Cloudiness { get; set; }
        public virtual Precipitation Precipitation { get; set; }
        public virtual Wind Wind { get; set; }
        public virtual int WindMax { get; set; }
        public virtual int WindMin { get; set; }
        public virtual Clarification WindClarification { get; set; }
        public virtual int WindClarificationMax { get; set; }
        public virtual int WindClarificationMin { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual int TemperatureMax { get; set; }
        public virtual int TemperatureMin { get; set; }
        public virtual Clarification TemperatureClarification { get; set; }
        public virtual int TemperatureClarificationMax { get; set; }
        public virtual int TemperatureClarificationMin { get; set; }        
    }
}