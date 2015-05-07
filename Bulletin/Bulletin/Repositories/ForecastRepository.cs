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
    public class ForecastRepository : IRepository<Models.Forecast>
    {
        #region IRepository<Forecast> Members

        void IRepository<Models.Forecast>.Save(Models.Forecast entity)
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

        void IRepository<Models.Forecast>.Update(Models.Forecast entity)
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

        void IRepository<Models.Forecast>.Delete(Models.Forecast entity)
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

        Models.Forecast IRepository<Models.Forecast>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Models.Forecast>().Add(Restrictions.Eq("ID", id)).UniqueResult<Models.Forecast>();
        }

        IList<Models.Forecast> IRepository<Models.Forecast>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Models.Forecast));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Models.Forecast>();
            }
        }

        #endregion
    }
}