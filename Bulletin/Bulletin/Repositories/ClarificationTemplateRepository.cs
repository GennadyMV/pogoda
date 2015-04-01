
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Bulletin.Common;
using NHibernate.Criterion;

namespace Bulletin.Repositories
{
    public class ClarificationTemplateRepository : IRepository<Bulletin.Models.ClarificationTemplate>
    {
        #region IRepository<Wind> Members

        void IRepository<Bulletin.Models.ClarificationTemplate>.Save(Bulletin.Models.ClarificationTemplate entity)
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

        void IRepository<Bulletin.Models.ClarificationTemplate>.Update(Bulletin.Models.ClarificationTemplate entity)
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

        void IRepository<Bulletin.Models.ClarificationTemplate>.Delete(Bulletin.Models.ClarificationTemplate entity)
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

        Bulletin.Models.ClarificationTemplate IRepository<Bulletin.Models.ClarificationTemplate>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Bulletin.Models.ClarificationTemplate>().Add(Restrictions.Eq("ID", id)).UniqueResult<Models.ClarificationTemplate>();
        }

        IList<Bulletin.Models.ClarificationTemplate> IRepository<Bulletin.Models.ClarificationTemplate>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.ClarificationTemplate));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Bulletin.Models.ClarificationTemplate>();
            }
        }

        #endregion
    }
}
