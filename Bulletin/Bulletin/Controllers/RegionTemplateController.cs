using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bulletin.Repositories;
using Bulletin.Common;
using Bulletin.Models;

namespace Bulletin.Controllers
{
    public class RegionTemplateController : Controller
    {
        //
        // GET: /RegoinTemplate/

        public ActionResult Index()
        {
            IRepository<Models.RegionTemplate> repo = new RegionTemplateRepository();
            return View(repo.GetAll());
        }

        //
        // GET: /RegoinTemplate/Details/5

        public ActionResult Details(int id)
        {
            IRepository<RegionTemplate> repo = new RegionTemplateRepository();
            return View(repo.GetById(id));
        }

        //
        // GET: /RegoinTemplate/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /RegoinTemplate/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string name = collection.Get("Name");
                int deltawind = 0;
                if (collection.Get("Deltawind") != null)
                {
                    deltawind = Convert.ToInt32(collection.Get("Deltawind"));
                }
                int deltatemperature = 0;
                if (collection.Get("Deltatemperature") != null)
                {
                    deltatemperature = Convert.ToInt32(collection.Get("Deltatemperature"));
                }

                int territory = (int)Territory.Region;
                if (collection.Get("Territory") != null)
                {
                    territory =  Convert.ToInt32(collection.Get("Territory"));
                }

                RegionTemplate region = new RegionTemplate() { Name = name, 
                                                            Deltawind = deltawind, 
                                                            Deltatemperature = deltatemperature,
                                                            Territory = territory};

                IRepository<RegionTemplate> repo = new RegionTemplateRepository();
                repo.Save(region);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message + ex.Source + ex.StackTrace + ex.InnerException;
                return View();
            }
        }

        //
        // GET: /RegoinTemplate/CreateRegion

        public ActionResult CreateRegion()
        {
            return View();
        }

        //
        // GET: /RegoinTemplate/CreateLocality

        public ActionResult CreateLocality()
        {
            return View();
        } 
        
        //
        // GET: /RegoinTemplate/Edit/5
 
        public ActionResult Edit(int id)
        {
            IRepository<RegionTemplate> repo = new RegionTemplateRepository();
            return View(repo.GetById(id));
        }

        //
        // POST: /RegoinTemplate/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                string name = collection.Get("Name");
                int deltawind = 0;
                if (collection.Get("Deltawind") != null)
                {
                    deltawind = Convert.ToInt32(collection.Get("Deltawind"));
                }
                int deltatemperature = 0;
                if (collection.Get("Deltatemperature") != null)
                {
                    deltatemperature = Convert.ToInt32(collection.Get("Deltatemperature"));
                }

                int territory = (int)Territory.Region;
                if (collection.Get("Territory") != null)
                {
                    territory = Convert.ToInt32(collection.Get("Territory"));
                }

                RegionTemplate region = new RegionTemplate() { ID = id, 
                                                            Name = name,
                                                            Deltawind = deltawind,
                                                            Deltatemperature = deltatemperature,
                                                            Territory = territory};

                IRepository<RegionTemplate> repo = new RegionTemplateRepository();
                repo.Update(region);
 
                return RedirectToAction("Index");
            }
            catch
            {                
                return View();
            }
        }

        //
        // GET: /RegoinTemplate/Delete/5
 
        public ActionResult Delete(int id)
        {
            IRepository<Models.RegionTemplate> repo = new RegionTemplateRepository();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        //
        // POST: /RegoinTemplate/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                IRepository<Models.RegionTemplate> repo = new RegionTemplateRepository();
                repo.Delete(repo.GetById(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
