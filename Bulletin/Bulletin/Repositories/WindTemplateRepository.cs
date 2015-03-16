
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using NHibernate;
    using Bulletin.Common;
    using NHibernate.Criterion;

    namespace Bulletin.Repositories
    {
        public class WindTemplateRepository : IRepository<Bulletin.Models.WindTemplate>
        {
            #region IRepository<Wind> Members

            void IRepository<Bulletin.Models.WindTemplate>.Save(Bulletin.Models.WindTemplate entity)
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

            void IRepository<Bulletin.Models.WindTemplate>.Update(Bulletin.Models.WindTemplate entity)
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

            void IRepository<Bulletin.Models.WindTemplate>.Delete(Bulletin.Models.WindTemplate entity)
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

            Bulletin.Models.WindTemplate IRepository<Bulletin.Models.WindTemplate>.GetById(int id)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.CreateCriteria<Bulletin.Models.WindTemplate>().Add(Restrictions.Eq("ID", id)).UniqueResult<Models.WindTemplate>();
            }

            IList<Bulletin.Models.WindTemplate> IRepository<Bulletin.Models.WindTemplate>.GetAll()
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.WindTemplate));
                    criteria.AddOrder(Order.Desc("ID"));
                    return criteria.List<Bulletin.Models.WindTemplate>();
                }
            }

            #endregion
        }
    }
