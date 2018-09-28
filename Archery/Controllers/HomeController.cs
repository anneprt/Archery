﻿using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["test"] = "rtest";
            ViewData["Title"] = "Accueil";
            return View();
        }

        //[Route ("a-propos")]
        public ActionResult About()
        {
           
            var modelInfo = new Info
            {
                DevName = "Anne",
                ContactMail = "anne@anne.com",
                CreatedDate = DateTime.Now
            };
            return View(modelInfo);
        }
    }
}