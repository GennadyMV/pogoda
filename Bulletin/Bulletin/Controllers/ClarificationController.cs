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
    public class ClarificationController : Controller
    {
        //
        // GET: /ClarificationTemplate/

        public ActionResult Index()
        {
            IRepository<Models.Clarification> repo = new ClarificationRepository();
            return View(repo.GetAll());
        }

        //
        // GET: /ClarificationTemplate/Details/5

        public ActionResult Details(int id)
        {
            IRepository<Clarification> repo = new ClarificationRepository();
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
                Clarification clarification = new Clarification() { Name = name };

                IRepository<Clarification> repo = new ClarificationRepository();
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
            IRepository<Clarification> repo = new ClarificationRepository();
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
                Clarification clarification = new Clarification() { ID = id, Name = name };

                IRepository<Clarification> repo = new ClarificationRepository();
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
            IRepository<Models.Clarification> repo = new ClarificationRepository();
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
                IRepository<Models.Clarification> repo = new ClarificationRepository();
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
