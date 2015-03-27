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
                string param_name = collection.Get("Name");
                Group group = new Group() { Name = param_name };
                if (collection.Get("Abonents") != null)
                {
                    string param_abonents = collection.Get("Abonents"); ;
                    string[] arrayAbonents = param_abonents.Split(',');

                    foreach (string str in arrayAbonents)
                    {
                        int AbonentID = Convert.ToInt32(str);
                        Abonent abonent = new Abonent();
                        IRepository<Abonent> repo_abonent = new AbonentRepository();
                        abonent = repo_abonent.GetById(AbonentID);

                        group.Abonents.Add(abonent);
                    }
                }


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
                string param_name = collection.Get("Name");
                IRepository<Group> repo = new GroupRepository();
                Group group = new Group();
                group = repo.GetById(id);
                group.Name = param_name;
                group.ClearAbonents();
                if (collection.Get("Abonents") != null)
                {
                    string param_abonents = collection.Get("Abonents"); ;
                    string[] arrayAbonents = param_abonents.Split(',');

                    foreach (string str in arrayAbonents)
                    {
                        int AbonentID = Convert.ToInt32(str);
                        Abonent abonent = new Abonent();
                        IRepository<Abonent> repo_abonent = new AbonentRepository();
                        abonent = repo_abonent.GetById(AbonentID);

                        group.Abonents.Add(abonent);
                    }
                }

                repo.Update(group);
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
