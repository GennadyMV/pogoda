using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Bulletin.Common;
using NHibernate.Criterion;

namespace Bulletin.Repositories
{
    public class AbonentRepository : IRepository<Bulletin.Models.Abonent>
    {
        #region IRepository<Cloudiness> Members

        void IRepository<Bulletin.Models.Abonent>.Save(Bulletin.Models.Abonent entity)
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

        void IRepository<Bulletin.Models.Abonent>.Update(Bulletin.Models.Abonent entity)
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

        void IRepository<Bulletin.Models.Abonent>.Delete(Bulletin.Models.Abonent entity)
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

        Bulletin.Models.Abonent IRepository<Bulletin.Models.Abonent>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Bulletin.Models.Abonent>().Add(Restrictions.Eq("ID", id)).UniqueResult<Bulletin.Models.Abonent>();
        }

        IList<Bulletin.Models.Abonent> IRepository<Bulletin.Models.Abonent>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.Abonent));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Bulletin.Models.Abonent>();
            }
        }

        #endregion
    }
}