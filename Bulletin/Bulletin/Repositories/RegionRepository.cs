
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using NHibernate;
    using Bulletin.Common;
    using NHibernate.Criterion;
using Bulletin.Models;

    namespace Bulletin.Repositories
    {
        public class RegionRepository : IRepository<Bulletin.Models.Region>
        {
            #region IRepository<Region> Members

            void IRepository<Bulletin.Models.Region>.Save(Bulletin.Models.Region entity)
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

            void IRepository<Bulletin.Models.Region>.Update(Bulletin.Models.Region entity)
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

            void IRepository<Bulletin.Models.Region>.Delete(Bulletin.Models.Region entity)
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

            Bulletin.Models.Region IRepository<Bulletin.Models.Region>.GetById(int id)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.CreateCriteria<Bulletin.Models.Region>().Add(Restrictions.Eq("ID", id)).UniqueResult<Models.Region>();
            }

            IList<Bulletin.Models.Region> IRepository<Bulletin.Models.Region>.GetAll()
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.Region));
                    criteria.AddOrder(Order.Desc("ID"));
                    return criteria.List<Bulletin.Models.Region>();
                }
            }


            public static IList<Bulletin.Models.Region> GetAllForTerritory()
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    /*
                     * http://stackoverflow.com/questions/835214/using-nhibernate-to-query-with-not-in-in-the-where-clause
                    DetachedCriteria c = DetachedCriteria.For<Territory>()
    .SetProjection(Projections.Property("Region"))
    .Add(Restrictions.Eq("Year", 2008))
    .Add(Restrictions.Eq("Month", 4));
                    session.CreateCriteria(typeof(Publisher))
                        .Add(Subqueries.PropertyNotIn("Id", c))
                        .List();
                
                     * */

                    ICriteria criteria = session.CreateCriteria(typeof(Bulletin.Models.Region));
                    criteria.AddOrder(Order.Desc("ID"));
                    criteria.Add(Restrictions.IsNull("Territory"));
                    return criteria.List<Bulletin.Models.Region>();
                }
            }

            
            #endregion
        }
    }
