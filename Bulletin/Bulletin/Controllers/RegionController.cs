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
    public class RegionController : Controller
    {
        //
        // GET: /Regoin/

        public ActionResult Index()
        {
            IRepository<Models.Region> repo = new RegionRepository();
            return View(repo.GetAll());
        }

        //
        // GET: /Regoin/Details/5

        public ActionResult Details(int id)
        {
            IRepository<Region> repo = new RegionRepository();
            return View(repo.GetById(id));
        }

        //
        // GET: /Regoin/Create

        public ActionResult Create()
        {            
            return View();
        } 

        //
        // POST: /Regoin/Create

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
                
                
                Region region = new Region() { Name = name, 
                                                            Deltawind = deltawind, 
                                                            Deltatemperature = deltatemperature};

                IRepository<Region> repo = new RegionRepository();
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
        // GET: /Regoin/Edit/5
 
        public ActionResult Edit(int id)
        {
            IRepository<Region> repo = new RegionRepository();
            return View(repo.GetById(id));
        }

        //
        // POST: /Regoin/Edit/5

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

                Region region = new Region() { ID = id, 
                                                            Name = name,
                                                            Deltawind = deltawind,
                                                            Deltatemperature = deltatemperature};


                IRepository<Region> repo = new RegionRepository();
                repo.Update(region);
 
                return RedirectToAction("Index");
            }
            catch
            {                
                return View();
            }
        }

        //
        // GET: /Regoin/Delete/5
 
        public ActionResult Delete(int id)
        {
            IRepository<Models.Region> repo = new RegionRepository();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        //
        // POST: /Regoin/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                IRepository<Models.Region> repo = new RegionRepository();
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
