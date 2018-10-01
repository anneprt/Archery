using Archery.Data;
using Archery.Models;
using Archery.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;

namespace Archery.Controllers
{
    public class ArchersController:BaseController

    {
        

        // GET: Players
        public ActionResult Subscribe()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe([Bind(Exclude ="ID")]Archer archer)
        {
            if(DateTime.Now.AddYears(-9)<= archer.BirthDate)
            {
                //ViewBag.Erreur = "Date de naissance invalide";
                // return View();
                //ModelState.AddModelError("BirthDate", "Date de naissance invalide");
            }
            if (ModelState.IsValid)
            {
                archer.Password = Extension.HashMD5(archer.Password);
                archer.Password.HashMD5();
                db.Archers.Add(archer);
                db.SaveChanges();


                //TempData["Message"] = "Archer Enregistré";
                Display("Archer enregistré");
                return RedirectToAction("index", "home");

            }
            
            return View();
        }

        private void Display(string v)
        {
            throw new NotImplementedException();
        }

       

    }
}