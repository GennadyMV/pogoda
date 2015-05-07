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
    public class ValueRepository : IRepository<Models.Value>
    {
        #region IRepository<Value> Members

        void IRepository<Models.Value>.Save(Models.Value entity)
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

        void IRepository<Models.Value>.Update(Models.Value entity)
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

        void IRepository<Models.Value>.Delete(Models.Value entity)
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

        Models.Value IRepository<Models.Value>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Models.Value>().Add(Restrictions.Eq("ID", id)).UniqueResult<Models.Value>();
        }

        IList<Models.Value> IRepository<Models.Value>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Models.Value));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Models.Value>();
            }
        }

        #endregion
    }
}