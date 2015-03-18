using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bulletin.Repositories;
using Bulletin.Common;

namespace Bulletin.Controllers
{
    public class BulletinsController : Controller
    {
        //
        // GET: /Bulletins/

        public ActionResult Index()
        {
            IRepository<Models.Bulletin> repo = new BulletinRepository();

            return View(repo.GetAll());
        }

        //
        // GET: /Bulletins/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Bulletins/Create

        public ActionResult Create()
        {
            ViewBag.DateTime = DateTime.Now.ToShortDateString();
            return View();
        } 

        //
        // POST: /Bulletins/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Bulletins/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Bulletins/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Bulletins/Delete/5
 
        public ActionResult Delete(int id)
        {
            IRepository<Models.Bulletin> repo = new BulletinRepository();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        //
        // POST: /Bulletins/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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
