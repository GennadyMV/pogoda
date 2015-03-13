using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Bulletin.Common;
using NHibernate.Criterion;

namespace Bulletin.Repositories
{
    public class CloudinessRepository : IRepository<Bulletin.Models.Cloudiness>
    {
        #region IRepository<Cloudiness> Members

        void IRepository<Bulletin.Models.Cloudiness>.Save(Bulletin.Models.Cloudiness entity)
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

        void IRepository<Bulletin.Models.Cloudiness>.Update(Bulletin.Models.Cloudiness entity)
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

        void IRepository<Bulletin.Models.Cloudiness>.Delete(Bulletin.Models.Cloudiness entity)
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

        Bulletin.Models.Cloudiness IRepository<Bulletin.Models.Cloudiness>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Bulletin.Models.Cloudiness>().Add(Restrictions.Eq("ID", id)).UniqueResult<Bulletin.Models.Cloudiness>();
        }

        IList<Bulletin.Models.Cloudiness> IRepository<Bulletin.Models.Cloudiness>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.Cloudiness));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Bulletin.Models.Cloudiness>();
            }
        }

        #endregion
    }
}