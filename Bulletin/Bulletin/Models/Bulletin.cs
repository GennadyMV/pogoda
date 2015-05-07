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

        public virtual ICollection<Forecast> Forecasts { get; protected set; }
        public Bulletin()
        {
            Forecasts = new System.Collections.Generic.HashSet<Forecast>();
        }

        public virtual void ClearForecasts()
        {
            this.Forecasts.Clear();
        }

        public virtual Boolean IsExistForecast(int ForecastID)
        {
            foreach (var forecast in this.Forecasts)
            {
                if (forecast.ID == ForecastID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}