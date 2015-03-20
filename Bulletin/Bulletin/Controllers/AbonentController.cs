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
    public class AbonentController : Controller
    {
        //
        // GET: /Abonent/

        public ActionResult Index()
        {
            IRepository<Models.Abonent> repo = new AbonentRepository();
            return View(repo.GetAll());
        }

        //
        // GET: /Abonent/Details/5

        public ActionResult Details(int id)
        {
            IRepository<Abonent> repo = new AbonentRepository();
            return View(repo.GetById(id));
        }

        //
        // GET: /Abonent/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Abonent/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string name = collection.Get("Name");
                string email = collection.Get("Email");
                Abonent abonent = new Abonent() { Name = name, Email = email };

                IRepository<Abonent> repo = new AbonentRepository();
                repo.Save(abonent);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Abonent/Edit/5

        public ActionResult Edit(int id)
        {
            IRepository<Abonent> repo = new AbonentRepository();
            return View(repo.GetById(id));
        }

        //
        // POST: /Abonent/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                string name = collection.Get("Name");
                string email = collection.Get("Email");
                Abonent abonent = new Abonent() { ID = id, Name = name, Email = email };

                IRepository<Abonent> repo = new AbonentRepository();
                repo.Update(abonent);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Abonent/Delete/5

        public ActionResult Delete(int id)
        {
            IRepository<Models.Abonent> repo = new AbonentRepository();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        //
        // POST: /Abonent/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                IRepository<Models.Abonent> repo = new AbonentRepository();
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
