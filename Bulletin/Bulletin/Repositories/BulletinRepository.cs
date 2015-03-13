using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bulletin.Common;
using Bulletin.Models;
using NHibernate;
using NHibernate.Criterion;

namespace Bulletin.Repositories
{
    public class BulletinRepository : IRepository<Models.Bulletin>
    {
        #region IRepository<Category> Members

        void IRepository<Models.Bulletin>.Save(Models.Bulletin entity)
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

        void IRepository<Models.Bulletin>.Update(Models.Bulletin entity)
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

        void IRepository<Models.Bulletin>.Delete(Models.Bulletin entity)
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

        Models.Bulletin IRepository<Models.Bulletin>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Models.Bulletin>().Add(Restrictions.Eq("ID", id)).UniqueResult<Models.Bulletin>();
        }

        IList<Models.Bulletin> IRepository<Models.Bulletin>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Models.Bulletin));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Models.Bulletin>();
            }
        }

        #endregion
    }
}