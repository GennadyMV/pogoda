using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bulletin.Common;
using Bulletin.Repositories;
using System.Net.Mail;
using System.Net;

namespace Bulletin.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Settings/

        public ActionResult Index()
        {
            IRepository<Models.Settings> repo = new SettingsRepository();
            Models.Settings settings;
            List<Models.Settings> theSettings = (List<Models.Settings>) repo.GetAll();
            if (theSettings.Count == 0) {
                settings = new Models.Settings();
                repo.Save(settings);                
            } 
            else
            {
                settings = theSettings[0];
            }
            return RedirectToAction("Details", new {ID = settings.ID});
        }

        //
        // GET: /Settings/Details/5

        public ActionResult Details(int id)
        {
            IRepository<Models.Settings> repo = new SettingsRepository();
            return View(repo.GetById(id));
        }

        //
        // GET: /Settings/Edit/5

        public ActionResult Edit(int id)
        {
            IRepository<Models.Settings> repo = new SettingsRepository();
            return View(repo.GetById(id));
        }

        //
        // POST: /Settings/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                string smtp_host = collection.Get("smtp_host");
                string smtp_port = collection.Get("smtp_port");
                string smtp_user = collection.Get("smtp_user");
                string msg_from = collection.Get("msg_from");
                string msg_subject = collection.Get("msg_subject");
                Models.Settings settings = new Models.Settings() { ID = id, 
                                                                   SMTP_HOST = smtp_host,
                                                                   SMTP_PORT = smtp_port,
                                                                   SMTP_USER = smtp_user,
                                                                   MSG_FROM = msg_from,
                                                                   MSG_SUBJECT = msg_subject};

                IRepository<Models.Settings> repo = new SettingsRepository();
                repo.Update(settings);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Settings/Delete/5

        public ActionResult Delete(int id)
        {
            IRepository<Models.Settings> repo = new SettingsRepository();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        public ActionResult SmtpTest(string smtp_host, string smtp_user, int smtp_port, string msg_from, string msg_to, string msg_subject)
        {
            try
            {
                ViewBag.Msg = "Успешно";
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp_host);
                mail.From = new MailAddress(msg_to);
                mail.To.Add(msg_to);
                mail.Subject = msg_subject;
                mail.IsBodyHtml = true;
                mail.Body = "<p>test</p>";
                SmtpServer.Port = smtp_port;
                SmtpServer.EnableSsl = false;
                NetworkCredential UserInfo = new NetworkCredential("dvmeteo@dvugms.khv.ru", "dvmeteo");
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = UserInfo;
                
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
            } 

            return View();
        }

    }
}
