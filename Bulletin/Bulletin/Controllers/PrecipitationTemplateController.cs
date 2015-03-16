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
    public class PrecipitationTemplateController : Controller
    {
        //
        // GET: /PrecipitationTemplate/

        public ActionResult Index()
        {
            IRepository<Models.PrecipitationTemplate> repo = new PrecipitationTemplateRepository();
            return View(repo.GetAll());
        }

        //
        // GET: /PrecipitationTemplate/Details/5

        public ActionResult Details(int id)
        {
            IRepository<PrecipitationTemplate> repo = new PrecipitationTemplateRepository();
            return View(repo.GetById(id));
        }

        //
        // GET: /PrecipitationTemplate/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PrecipitationTemplate/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string name = collection.Get("Name");
                PrecipitationTemplate precipitation = new PrecipitationTemplate() { Name = name };

                IRepository<PrecipitationTemplate> repo = new PrecipitationTemplateRepository();
                repo.Save(precipitation);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /PrecipitationTemplate/Edit/5
 
        public ActionResult Edit(int id)
        {
            IRepository<PrecipitationTemplate> repo = new PrecipitationTemplateRepository();
            return View(repo.GetById(id));
        }

        //
        // POST: /PrecipitationTemplate/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                string name = collection.Get("Name");
                PrecipitationTemplate precipitation = new PrecipitationTemplate() { ID = id, Name = name };

                IRepository<PrecipitationTemplate> repo = new PrecipitationTemplateRepository();
                repo.Update(precipitation); 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PrecipitationTemplate/Delete/5
 
        public ActionResult Delete(int id)
        {
            IRepository<Models.PrecipitationTemplate> repo = new PrecipitationTemplateRepository();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        //
        // POST: /PrecipitationTemplate/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                IRepository<Models.PrecipitationTemplate> repo = new PrecipitationTemplateRepository();
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
