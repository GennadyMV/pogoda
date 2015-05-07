using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Bulletin.Common;
using NHibernate.Criterion;

namespace Bulletin.Repositories
{
    public class ConditionTemplateRepository : IRepository<Bulletin.Models.Condition>
    {
        #region IRepository<Condition> Members

        void IRepository<Bulletin.Models.Condition>.Save(Bulletin.Models.Condition entity)
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

        void IRepository<Bulletin.Models.Condition>.Update(Bulletin.Models.Condition entity)
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

        void IRepository<Bulletin.Models.Condition>.Delete(Bulletin.Models.Condition entity)
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

        Bulletin.Models.Condition IRepository<Bulletin.Models.Condition>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Bulletin.Models.Condition>().Add(Restrictions.Eq("ID", id)).UniqueResult<Bulletin.Models.Condition>();
        }

        IList<Bulletin.Models.Condition> IRepository<Bulletin.Models.Condition>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.Condition));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Bulletin.Models.Condition>();
            }
        }

        #endregion
    }
}