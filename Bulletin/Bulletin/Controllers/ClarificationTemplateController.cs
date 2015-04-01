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
    public class ClarificationTemplateController : Controller
    {
        //
        // GET: /ClarificationTemplate/

        public ActionResult Index()
        {
            IRepository<Models.ClarificationTemplate> repo = new ClarificationTemplateRepository();
            return View(repo.GetAll());
        }

        //
        // GET: /ClarificationTemplate/Details/5

        public ActionResult Details(int id)
        {
            IRepository<ClarificationTemplate> repo = new ClarificationTemplateRepository();
            return View(repo.GetById(id));
        }

        //
        // GET: /ClarificationTemplate/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ClarificationTemplate/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string name = collection.Get("Name");
                ClarificationTemplate clarification = new ClarificationTemplate() { Name = name };

                IRepository<ClarificationTemplate> repo = new ClarificationTemplateRepository();
                repo.Save(clarification);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ClarificationTemplate/Edit/5

        public ActionResult Edit(int id)
        {
            IRepository<ClarificationTemplate> repo = new ClarificationTemplateRepository();
            return View(repo.GetById(id));
        }

        //
        // POST: /ClarificationTemplate/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                string name = collection.Get("Name");
                ClarificationTemplate clarification = new ClarificationTemplate() { ID = id, Name = name };

                IRepository<ClarificationTemplate> repo = new ClarificationTemplateRepository();
                repo.Update(clarification);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ClarificationTemplate/Delete/5

        public ActionResult Delete(int id)
        {
            IRepository<Models.ClarificationTemplate> repo = new ClarificationTemplateRepository();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        //
        // POST: /ClarificationTemplate/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                IRepository<Models.ClarificationTemplate> repo = new ClarificationTemplateRepository();
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
