﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ActionMailer.Net.Mvc;
using Domain.Entitis;
using TorgiDemoMVC.UI.Models;

namespace TorgiDemoMVC.UI.Controllers
{
    public class EmailController : MailerBase
    {
        public EmailResult SendMail(EmailModel model, IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                To.Add(user.Email);
            }
            From = "mailer@gmail.com";
            Subject = model.Subject;
            MessageEncoding = Encoding.UTF8;
            return Email("SendMail", model);
        }
    }
}