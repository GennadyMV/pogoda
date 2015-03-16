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

        public virtual RegionTemplate Region { get; set; }
        // Осадки
        public virtual PrecipitationTemplate Precipitation { get; set; }
        // Ветер
        public virtual WindTemplate Wind { get; set; }
        public virtual int WindValueMin { get; set; }
        public virtual int WindValueMax { get; set; }
        // Температура
        public virtual int TempDayMin { get; set; }
        public virtual int TempDayMax { get; set; }
        public virtual int TempNightMin { get; set; }
        public virtual int TempNightMax { get; set; }
        // Явления
        public virtual ConditionTemplate Condition { get; set; }
        // Облачность
        public virtual CloudinessTemplate Cloudiness { get; set; }
    }
}