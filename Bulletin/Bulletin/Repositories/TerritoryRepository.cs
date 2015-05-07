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
    public class TerritoryRepository : IRepository<Models.Territory>
    {
        #region IRepository<Territory> Members

        void IRepository<Models.Territory>.Save(Models.Territory entity)
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

        void IRepository<Models.Territory>.Update(Models.Territory entity)
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

        void IRepository<Models.Territory>.Delete(Models.Territory entity)
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

        Models.Territory IRepository<Models.Territory>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Models.Territory>().Add(Restrictions.Eq("ID", id)).UniqueResult<Models.Territory>();
        }

        IList<Models.Territory> IRepository<Models.Territory>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Models.Territory));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Models.Territory>();
            }
        }

        #endregion
    }
}