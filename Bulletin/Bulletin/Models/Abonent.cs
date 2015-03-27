using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulletin.Models
{
    public class Abonent
    {
        public virtual int ID { get; set; }
        public virtual string Name  { get; set; }
        public virtual string Email { get; set; }
        public Abonent()
        {
            this._Groups = new System.Collections.Generic.HashSet<Group>();
        }
        private ICollection<Group> _Groups;
        public virtual ICollection<Group> Groups
        {
            get
            {
                return this._Groups;
            }
            set
            {
                this._Groups = value;
            }
        }
        public virtual void ClearGroups()
        {
            this.Groups.Clear();
        }

        public virtual Boolean IsExistGroup(int GroupID)
        {
            foreach (var theGroup in this.Groups)
            {
                if (theGroup.ID == GroupID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}