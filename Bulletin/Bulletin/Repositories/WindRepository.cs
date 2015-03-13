
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using NHibernate;
    using Bulletin.Common;
    using NHibernate.Criterion;

    namespace Bulletin.Repositories
    {
        public class WindRepository : IRepository<Bulletin.Models.Wind>
        {
            #region IRepository<Wind> Members

            void IRepository<Bulletin.Models.Wind>.Save(Bulletin.Models.Wind entity)
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

            void IRepository<Bulletin.Models.Wind>.Update(Bulletin.Models.Wind entity)
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

            void IRepository<Bulletin.Models.Wind>.Delete(Bulletin.Models.Wind entity)
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

            Bulletin.Models.Wind IRepository<Bulletin.Models.Wind>.GetById(int id)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.CreateCriteria<Bulletin.Models.Wind>().Add(Restrictions.Eq("ID", id)).UniqueResult<Models.Wind>();
            }

            IList<Bulletin.Models.Wind> IRepository<Bulletin.Models.Wind>.GetAll()
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.Wind));
                    criteria.AddOrder(Order.Desc("ID"));
                    return criteria.List<Bulletin.Models.Wind>();
                }
            }

            #endregion
        }
    }
