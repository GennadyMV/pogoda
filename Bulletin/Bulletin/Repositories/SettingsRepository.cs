using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Bulletin.Common;
using NHibernate.Criterion;

namespace Bulletin.Repositories
{
    public class SettingsRepository : IRepository<Bulletin.Models.Settings>
    {
        #region IRepository<Cloudiness> Members

        void IRepository<Bulletin.Models.Settings>.Save(Bulletin.Models.Settings entity)
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

        void IRepository<Bulletin.Models.Settings>.Update(Bulletin.Models.Settings entity)
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

        void IRepository<Bulletin.Models.Settings>.Delete(Bulletin.Models.Settings entity)
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

        Bulletin.Models.Settings IRepository<Bulletin.Models.Settings>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Bulletin.Models.Settings>().Add(Restrictions.Eq("ID", id)).UniqueResult<Bulletin.Models.Settings>();
        }

        IList<Bulletin.Models.Settings> IRepository<Bulletin.Models.Settings>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.Settings));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Bulletin.Models.Settings>();
            }
        }

        #endregion
    }
}