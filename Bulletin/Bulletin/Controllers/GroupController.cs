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
    public class GroupController : Controller
    {
        //
        // GET: /Group/

        public ActionResult Index()
        {
            IRepository<Models.Group> repo = new GroupRepository();
            return View(repo.GetAll());
        }

        //
        // GET: /Group/Details/5

        public ActionResult Details(int id)
        {
            IRepository<Group> repo = new GroupRepository();
            return View(repo.GetById(id));
        }

        //
        // GET: /Group/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Group/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string name = collection.Get("Name");
                Group group = new Group() { Name = name };

                IRepository<Group> repo = new GroupRepository();
                repo.Save(group);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Group/Edit/5

        public ActionResult Edit(int id)
        {
            IRepository<Group> repo = new GroupRepository();
            return View(repo.GetById(id));
        }

        //
        // POST: /Group/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                string name = collection.Get("Name");
                Group Group = new Group() { ID = id, Name = name };

                IRepository<Group> repo = new GroupRepository();
                repo.Update(Group);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Group/Delete/5

        public ActionResult Delete(int id)
        {
            IRepository<Models.Group> repo = new GroupRepository();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        //
        // POST: /Group/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                IRepository<Models.Group> repo = new GroupRepository();
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
