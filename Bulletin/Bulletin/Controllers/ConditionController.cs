﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bulletin.Repositories;
using Bulletin.Common;
using Bulletin.Models;

namespace Bulletin.Controllers
{
    public class ConditionController : Controller
    {
        //
        // GET: /ConditionTemplate/

        public ActionResult Index()
        {
            IRepository<Models.Condition> repo = new ConditionRepository();
            return View(repo.GetAll());
        }

        //
        // GET: /ConditionTemplate/Details/5

        public ActionResult Details(int id)
        {
            IRepository<Condition> repo = new ConditionRepository();
            return View(repo.GetById(id));
        }

        //
        // GET: /ConditionTemplate/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ConditionTemplate/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string name = collection.Get("Name");
                Condition condition = new Condition() { Name = name };

                IRepository<Condition> repo = new ConditionRepository();
                repo.Save(condition);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ConditionTemplate/Edit/5

        public ActionResult Edit(int id)
        {
            IRepository<Condition> repo = new ConditionRepository();
            return View(repo.GetById(id));
        }

        //
        // POST: /ConditionTemplate/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                string name = collection.Get("Name");
                Condition condition = new Condition() { ID = id, Name = name };

                IRepository<Condition> repo = new ConditionRepository();
                repo.Update(condition);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ConditionTemplate/Delete/5

        public ActionResult Delete(int id)
        {
            IRepository<Models.Condition> repo = new ConditionRepository();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        //
        // POST: /ConditionTemplate/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                IRepository<Models.Condition> repo = new ConditionRepository();
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
