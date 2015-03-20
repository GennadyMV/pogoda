using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Bulletin.Common;
using NHibernate.Criterion;

namespace Bulletin.Repositories
{
    public class GroupRepository : IRepository<Bulletin.Models.Group>
    {
        #region IRepository<Cloudiness> Members

        void IRepository<Bulletin.Models.Group>.Save(Bulletin.Models.Group entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        void IRepository<Bulletin.Models.Group>.Update(Bulletin.Models.Group entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }

        void IRepository<Bulletin.Models.Group>.Delete(Bulletin.Models.Group entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        Bulletin.Models.Group IRepository<Bulletin.Models.Group>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Bulletin.Models.Group>().Add(Restrictions.Eq("ID", id)).UniqueResult<Bulletin.Models.Group>();
        }

        IList<Bulletin.Models.Group> IRepository<Bulletin.Models.Group>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.Group));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Bulletin.Models.Group>();
            }
        }

        #endregion
    }
}