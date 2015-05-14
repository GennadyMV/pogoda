using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bulletin.Common;
using Bulletin.Repositories;
using Bulletin.Models;

namespace Bulletin.Controllers
{
    public class TerritoryController : Controller
    {
        //
        // GET: /Territory/

        public ActionResult Index()
        {
            IRepository<Models.Territory> repo = new TerritoryRepository();
            return View(repo.GetAll());
        }

        //
        // GET: /Territory/Details/5

        public ActionResult Details(int id)
        {
            IRepository<Territory> repo = new TerritoryRepository();
            return View(repo.GetById(id));
        }

        //
        // GET: /Territory/Create

        public ActionResult Create()
        {
            ViewBag.Regions = RegionRepository.GetAllForTerritory();
            return View();
        }

        //
        // POST: /Territory/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string name = collection.Get("Name");
                Territory Territory = new Territory() { Name = name };

                string param_regions;
                string[] arrayRegions;
                if (collection.Get("Regions") != null)
                {
                    param_regions = collection.Get("Regions"); ;
                    arrayRegions = param_regions.Split(',');

                    foreach (string str in arrayRegions)
                    {
                        int RegionID = Convert.ToInt32(str);
                        Region region = new Region();
                        IRepository<Region> repo_region = new RegionRepository();
                        region = repo_region.GetById(RegionID);

                        Territory.Regions.Add(region);
                    }
                }

                IRepository<Territory> repo = new TerritoryRepository();
                repo.Save(Territory);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Territory/Edit/5

        public ActionResult Edit(int id)
        {
            IRepository<Territory> repo = new TerritoryRepository();
            ViewBag.Regions = RegionRepository.GetAllForTerritory();
            return View(repo.GetById(id));
        }

        //
        // POST: /Territory/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                string name = collection.Get("Name");
                Territory Territory = new Territory();
                IRepository<Territory> repo = new TerritoryRepository();
                Territory = repo.GetById(id);
                Territory.ClearRegions();
                Territory.Name = name;
                string param_regions;
                string[] arrayRegions;
                if (collection.Get("Regions") != null)
                {
                    param_regions = collection.Get("Regions"); ;
                    arrayRegions = param_regions.Split(',');

                    foreach (string str in arrayRegions)
                    {
                        int RegionID = Convert.ToInt32(str);
                        Region region = new Region();
                        IRepository<Region> repo_region = new RegionRepository();
                        region = repo_region.GetById(RegionID);

                        Territory.Regions.Add(region);
                    }
                }                
                
                repo.Update(Territory);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Territory/Delete/5

        public ActionResult Delete(int id)
        {
            IRepository<Models.Territory> repo = new TerritoryRepository();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        //
        // POST: /Territory/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                IRepository<Models.Territory> repo = new TerritoryRepository();
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
