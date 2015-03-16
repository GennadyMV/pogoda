
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using NHibernate;
    using Bulletin.Common;
    using NHibernate.Criterion;

    namespace Bulletin.Repositories
    {
        public class RegionTemplateRepository : IRepository<Bulletin.Models.RegionTemplate>
        {
            #region IRepository<Region> Members

            void IRepository<Bulletin.Models.RegionTemplate>.Save(Bulletin.Models.RegionTemplate entity)
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

            void IRepository<Bulletin.Models.RegionTemplate>.Update(Bulletin.Models.RegionTemplate entity)
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

            void IRepository<Bulletin.Models.RegionTemplate>.Delete(Bulletin.Models.RegionTemplate entity)
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

            Bulletin.Models.RegionTemplate IRepository<Bulletin.Models.RegionTemplate>.GetById(int id)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.CreateCriteria<Bulletin.Models.RegionTemplate>().Add(Restrictions.Eq("ID", id)).UniqueResult<Models.RegionTemplate>();
            }

            IList<Bulletin.Models.RegionTemplate> IRepository<Bulletin.Models.RegionTemplate>.GetAll()
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.RegionTemplate));
                    criteria.AddOrder(Order.Desc("ID"));
                    return criteria.List<Bulletin.Models.RegionTemplate>();
                }
            }

            #endregion
        }
    }
