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
    public class WindTemplateController : Controller
    {
        //
        // GET: /WindTemplate/

        public ActionResult Index()
        {
            IRepository<Models.WindTemplate> repo = new WindTemplateRepository();
            return View(repo.GetAll());
        }

        //
        // GET: /WindTemplate/Details/5

        public ActionResult Details(int id)
        {
            IRepository<WindTemplate> repo = new WindTemplateRepository();
            return View(repo.GetById(id));
        }

        //
        // GET: /WindTemplate/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /WindTemplate/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string name = collection.Get("Name");
                WindTemplate wind = new WindTemplate() { Name = name };

                IRepository<WindTemplate> repo = new WindTemplateRepository();
                repo.Save(wind);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /WindTemplate/Edit/5
 
        public ActionResult Edit(int id)
        {
            IRepository<WindTemplate> repo = new WindTemplateRepository();
            return View(repo.GetById(id));
        }

        //
        // POST: /WindTemplate/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                string name = collection.Get("Name");
                WindTemplate wind = new WindTemplate() { ID = id, Name = name };

                IRepository<WindTemplate> repo = new WindTemplateRepository();
                repo.Update(wind);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /WindTemplate/Delete/5
 
        public ActionResult Delete(int id)
        {
            IRepository<Models.WindTemplate> repo = new WindTemplateRepository();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        //
        // POST: /WindTemplate/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                IRepository<Models.Bulletin> repo = new BulletinRepository();
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
