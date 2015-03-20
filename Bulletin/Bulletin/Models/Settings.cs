using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulletin.Models
{
    public class Settings
    {
        public Settings()
        {
            SMTP_HOST = "";
            SMTP_USER = "";
            SMTP_PORT = "";
            MSG_FROM = "";
            MSG_SUBJECT = "";
        }
        public virtual int ID { get; set; }
        public virtual string SMTP_HOST { get; set; }
        public virtual string SMTP_USER { get; set; }
        public virtual string SMTP_PORT { get; set; }
        public virtual string MSG_FROM { get; set; }
        public virtual string MSG_SUBJECT { get; set; }
    }
}