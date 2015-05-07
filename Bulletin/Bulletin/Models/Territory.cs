using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulletin.Models
{
    public class Territory
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
        public Territory()
        {
            Regions = new System.Collections.Generic.HashSet<Region>();
        }

        public virtual void ClearRegions()
        {
            this.Regions.Clear();
        }

        public virtual Boolean IsExistRegion(int RegionID)
        {
            foreach (var region in this.Regions)
            {
                if (region.ID == RegionID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}