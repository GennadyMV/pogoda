using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulletin.Models
{
    public class Group
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }

        public Group()
        {
            this._Abonents = new System.Collections.Generic.HashSet<Abonent>();
        }
        private ICollection<Abonent> _Abonents;
        public virtual ICollection<Abonent> Abonents
        {
            get
            {
                return this._Abonents;
            }
            set
            {
                this._Abonents = value;
            }
        }
    }
}