
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using NHibernate;
    using Bulletin.Common;
    using NHibernate.Criterion;

    namespace Bulletin.Repositories
    {
        public class PrecipitationRepository : IRepository<Bulletin.Models.Precipitation>
        {
            #region IRepository<Precipitation> Members

            void IRepository<Bulletin.Models.Precipitation>.Save(Bulletin.Models.Precipitation entity)
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

            void IRepository<Bulletin.Models.Precipitation>.Update(Bulletin.Models.Precipitation entity)
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

            void IRepository<Bulletin.Models.Precipitation>.Delete(Bulletin.Models.Precipitation entity)
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

            Bulletin.Models.Precipitation IRepository<Bulletin.Models.Precipitation>.GetById(int id)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.CreateCriteria<Bulletin.Models.Precipitation>().Add(Restrictions.Eq("ID", id)).UniqueResult<Models.Precipitation>();
            }

            IList<Bulletin.Models.Precipitation> IRepository<Bulletin.Models.Precipitation>.GetAll()
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.Precipitation));
                    criteria.AddOrder(Order.Desc("ID"));
                    return criteria.List<Bulletin.Models.Precipitation>();
                }
            }

            #endregion
        }
    }
