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
    public class CloudinessTemplateController : Controller
    {
        //
        // GET: /CloudinessTemplate/

        public ActionResult Index()
        {
            IRepository<Models.CloudinessTemplate> repo = new CloudinessTemplateRepository();
            return View(repo.GetAll());
        }

        //
        // GET: /CloudinessTemplate/Details/5

        public ActionResult Details(int id)
        {
            IRepository<CloudinessTemplate> repo = new CloudinessTemplateRepository();
            return View(repo.GetById(id));
        }

        //
        // GET: /CloudinessTemplate/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CloudinessTemplate/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string name = collection.Get("Name");
                CloudinessTemplate cloudiness = new CloudinessTemplate() { Name = name };

                IRepository<CloudinessTemplate> repo = new CloudinessTemplateRepository();
                repo.Save(cloudiness);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CloudinessTemplate/Edit/5

        public ActionResult Edit(int id)
        {
            IRepository<CloudinessTemplate> repo = new CloudinessTemplateRepository();
            return View(repo.GetById(id));
        }

        //
        // POST: /CloudinessTemplate/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                string name = collection.Get("Name");
                CloudinessTemplate cloudiness = new CloudinessTemplate() { ID = id, Name = name };

                IRepository<CloudinessTemplate> repo = new CloudinessTemplateRepository();
                repo.Update(cloudiness);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CloudinessTemplate/Delete/5

        public ActionResult Delete(int id)
        {
            IRepository<Models.CloudinessTemplate> repo = new CloudinessTemplateRepository();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        //
        // POST: /CloudinessTemplate/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                IRepository<Models.CloudinessTemplate> repo = new CloudinessTemplateRepository();
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
