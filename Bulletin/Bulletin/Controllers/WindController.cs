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
    public class WindController : Controller
    {
        //
        // GET: /WindTemplate/

        public ActionResult Index()
        {
            IRepository<Models.Wind> repo = new WindRepository();
            return View(repo.GetAll());
        }

        //
        // GET: /WindTemplate/Details/5

        public ActionResult Details(int id)
        {
            IRepository<Wind> repo = new WindRepository();
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
                Wind wind = new Wind() { Name = name };

                IRepository<Wind> repo = new WindRepository();
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
            IRepository<Wind> repo = new WindRepository();
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
                Wind wind = new Wind() { ID = id, Name = name };

                IRepository<Wind> repo = new WindRepository();
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
            IRepository<Models.Wind> repo = new WindRepository();
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
                IRepository<Models.Wind> repo = new WindRepository();
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
