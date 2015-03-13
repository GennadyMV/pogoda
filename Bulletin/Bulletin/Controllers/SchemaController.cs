using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bulletin.Common;

namespace Bulletin.Controllers
{
    public class SchemaController : Controller
    {
        //
        // GET: /Shema/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Shema/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Shema/Update

        public ActionResult Update()
        {
            try
            {
                ViewBag.Msg = "Схема успешно обновлена";
                NHibernateHelper.UpdateSchema();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = String.Format("{0}\n{1}", ex.Message, ex.Source);
            }
            return View();
        } 

        //
        // GET: /Shema/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Shema/Create

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
        // GET: /Shema/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Shema/Edit/5

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
        // GET: /Shema/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Shema/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
