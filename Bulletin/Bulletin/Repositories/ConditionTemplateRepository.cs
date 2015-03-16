using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Bulletin.Common;
using NHibernate.Criterion;

namespace Bulletin.Repositories
{
    public class ConditionTemplateRepository : IRepository<Bulletin.Models.ConditionTemplate>
    {
        #region IRepository<Condition> Members

        void IRepository<Bulletin.Models.ConditionTemplate>.Save(Bulletin.Models.ConditionTemplate entity)
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

        void IRepository<Bulletin.Models.ConditionTemplate>.Update(Bulletin.Models.ConditionTemplate entity)
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

        void IRepository<Bulletin.Models.ConditionTemplate>.Delete(Bulletin.Models.ConditionTemplate entity)
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

        Bulletin.Models.ConditionTemplate IRepository<Bulletin.Models.ConditionTemplate>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Bulletin.Models.ConditionTemplate>().Add(Restrictions.Eq("ID", id)).UniqueResult<Bulletin.Models.ConditionTemplate>();
        }

        IList<Bulletin.Models.ConditionTemplate> IRepository<Bulletin.Models.ConditionTemplate>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.ConditionTemplate));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Bulletin.Models.ConditionTemplate>();
            }
        }

        #endregion
    }
}