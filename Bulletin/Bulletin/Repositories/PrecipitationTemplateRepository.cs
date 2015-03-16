
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using NHibernate;
    using Bulletin.Common;
    using NHibernate.Criterion;

    namespace Bulletin.Repositories
    {
        public class PrecipitationTemplateRepository : IRepository<Bulletin.Models.PrecipitationTemplate>
        {
            #region IRepository<Precipitation> Members

            void IRepository<Bulletin.Models.PrecipitationTemplate>.Save(Bulletin.Models.PrecipitationTemplate entity)
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

            void IRepository<Bulletin.Models.PrecipitationTemplate>.Update(Bulletin.Models.PrecipitationTemplate entity)
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

            void IRepository<Bulletin.Models.PrecipitationTemplate>.Delete(Bulletin.Models.PrecipitationTemplate entity)
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

            Bulletin.Models.PrecipitationTemplate IRepository<Bulletin.Models.PrecipitationTemplate>.GetById(int id)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.CreateCriteria<Bulletin.Models.PrecipitationTemplate>().Add(Restrictions.Eq("ID", id)).UniqueResult<Models.PrecipitationTemplate>();
            }

            IList<Bulletin.Models.PrecipitationTemplate> IRepository<Bulletin.Models.PrecipitationTemplate>.GetAll()
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.PrecipitationTemplate));
                    criteria.AddOrder(Order.Desc("ID"));
                    return criteria.List<Bulletin.Models.PrecipitationTemplate>();
                }
            }

            #endregion
        }
    }
