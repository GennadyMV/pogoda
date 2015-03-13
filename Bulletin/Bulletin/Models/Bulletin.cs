using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulletin.Models
{
    public class Bulletin
    {
        public virtual int ID { get; set; }
        public virtual DateTime Day { get; set; }
        public virtual string Name
        {
            get
            {
                return String.Format("Бюллетень за {0}",Day.ToShortDateString());
            }
        }

    }
}