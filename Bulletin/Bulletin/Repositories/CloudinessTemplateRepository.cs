using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Bulletin.Common;
using NHibernate.Criterion;

namespace Bulletin.Repositories
{
    public class CloudinessTemplateRepository : IRepository<Bulletin.Models.CloudinessTemplate>
    {
        #region IRepository<Cloudiness> Members

        void IRepository<Bulletin.Models.CloudinessTemplate>.Save(Bulletin.Models.CloudinessTemplate entity)
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

        void IRepository<Bulletin.Models.CloudinessTemplate>.Update(Bulletin.Models.CloudinessTemplate entity)
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

        void IRepository<Bulletin.Models.CloudinessTemplate>.Delete(Bulletin.Models.CloudinessTemplate entity)
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

        Bulletin.Models.CloudinessTemplate IRepository<Bulletin.Models.CloudinessTemplate>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Bulletin.Models.CloudinessTemplate>().Add(Restrictions.Eq("ID", id)).UniqueResult<Bulletin.Models.CloudinessTemplate>();
        }

        IList<Bulletin.Models.CloudinessTemplate> IRepository<Bulletin.Models.CloudinessTemplate>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.CloudinessTemplate));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Bulletin.Models.CloudinessTemplate>();
            }
        }

        #endregion
    }
}