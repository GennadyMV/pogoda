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
                string param_name = collection.Get("Name");
                string param_email = collection.Get("Email");
                Abonent abonent = new Abonent() { Name = param_name, Email = param_email };
                string param_groups;
                string[] arrayGroups;
                if (collection.Get("Groups") != null) {
                    param_groups = collection.Get("Groups"); ;
                    arrayGroups = param_groups.Split(',');

                    foreach (string str in arrayGroups)
                    {
                        int GroupID = Convert.ToInt32(str);
                        Group group = new Group();
                        IRepository<Group> repo_group = new GroupRepository();
                        group = repo_group.GetById(GroupID);

                        abonent.Groups.Add(group);
                    }
                }

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
            IRepository<Group> repo_groups = new GroupRepository();
            @ViewBag.Groups = repo_groups.GetAll();

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
                string param_name = collection.Get("Name");
                string param_email = collection.Get("Email");
                IRepository<Abonent> repo = new AbonentRepository();
                Abonent abonent = new Abonent();
                abonent = repo.GetById(id);
                abonent.Name = param_name;
                abonent.Email = param_email;
                abonent.ClearGroups();
                string param_groups;
                string[] arrayGroups;

                if (collection.Get("Groups") != null)
                {
                    param_groups = collection.Get("Groups"); ;
                    arrayGroups = param_groups.Split(',');

                    foreach (string str in arrayGroups)
                    {
                        int GroupID = Convert.ToInt32(str);
                        Group group = new Group();
                        IRepository<Group> repo_group = new GroupRepository();
                        group = repo_group.GetById(GroupID);

                        abonent.Groups.Add(group);
                    }


                }

                
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
