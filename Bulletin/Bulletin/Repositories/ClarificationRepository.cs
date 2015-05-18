
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Bulletin.Common;
using NHibernate.Criterion;

namespace Bulletin.Repositories
{
    public class ClarificationRepository : IRepository<Bulletin.Models.Clarification>
    {
        #region IRepository<Wind> Members

        void IRepository<Bulletin.Models.Clarification>.Save(Bulletin.Models.Clarification entity)
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

        void IRepository<Bulletin.Models.Clarification>.Update(Bulletin.Models.Clarification entity)
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

        void IRepository<Bulletin.Models.Clarification>.Delete(Bulletin.Models.Clarification entity)
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

        Bulletin.Models.Clarification IRepository<Bulletin.Models.Clarification>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Bulletin.Models.Clarification>().Add(Restrictions.Eq("ID", id)).UniqueResult<Models.Clarification>();
        }

        IList<Bulletin.Models.Clarification> IRepository<Bulletin.Models.Clarification>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.Clarification));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Bulletin.Models.Clarification>();
            }
        }

        #endregion
    }
}
