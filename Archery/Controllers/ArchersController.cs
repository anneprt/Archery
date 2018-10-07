
using Archery.Models;
using Archery.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using Archery.Areas.BackOffice.Models;
using Archery.Filters;
using System.Web.Services.Description;

namespace Archery.Controllers
{
    public class ArchersController : BaseController

    {

        // GET: Players
        public ActionResult Subscribe()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe([Bind(Exclude = "ID")]Archer archer)
        {
            if (DateTime.Now.AddYears(-9) <= archer.BirthDate)
            {
                //ViewBag.Erreur = "Date de naissance invalide";
                // return View();
                //ModelState.AddModelError("BirthDate", "Date de naissance invalide");
            }
            if (ModelState.IsValid)
            {
                //archer.Password = Extension.HashMD5(archer.Password);
                archer.Password = archer.Password.HashMD5();

                db.Configuration.ValidateOnSaveEnabled = false;
                db.Archers.Add(archer);
                db.SaveChanges();

                db.Configuration.ValidateOnSaveEnabled = true;
                //TempData["Message"] = "Archer Enregistré";
                Display("Archer enregistré");

                return RedirectToAction("index", "home");

            }

            return View();
        }

        [HttpGet]
        //[ArcherAuthentication]
        [Authentication(Type = "ARCHER")]
        public ActionResult SubscribeTournament(int? tournamentId)
        {
            if (tournamentId == null)
                return HttpNotFound();
            //ajout travail demande
            var tournament = db.Tournaments.SingleOrDefault(x => x.ID == tournamentId);
            Archer archer = (Archer)Session["ARCHER"];
            int countArcher = tournament.Shooters.Count(x => x.ArcherID == archer.ID);

            // controler si il reste des places pour le tournoi
            if (tournament.HasEnoughShooter())
            {
                Display("Vous ne pouvez pas vous inscrire, il n'y a plus de places disponibles", MessageType.ERROR);
                return View();
            }

            // contoler si l'archer s'est deja inscrit au tournoi
            if (countArcher > 0)
            {
                Display("Vous ne pouvez pas vous inscrire plusieurs fois à un tournoi", MessageType.ERROR);
                return View();
            }

            return View(tournament);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthenticationLoginViewModel model)
        {
            var hash = model.Password.HashMD5();
            var archer = db.Archers.SingleOrDefault(x => x.Mail == model.Mail && x.Password == hash);
            if (archer == null)
            {
                Display("Login/mot de passe incorrect", MessageType.ERROR);
                return View();
            }
            else
            {
                Session["ARCHER"] = archer;
                //if (TempData["REDIRECT"] != null)
                //    return Redirect(TempData["REDIRECT"].ToString());
                //else
                    return RedirectToAction("index", "home");
            }

        }

        public ActionResult Logout()
        {
            Session.Remove("ARCHER");
            return RedirectToAction("index", "home");
        }



    }
}