using Archery.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Affiche un message dans le layout success ou erreur
        /// </summary>
        /// <param name="text">le texte à afficher</param>
        /// <param name="type">le type de message</param>
        
        protected void Display(string text, MessageType type = MessageType.SUCCESS)//par defaut message success donc inutile de preciser dans l appel
        {
            var m = new Message(type, text);
            TempData["MESSAGE"] = m;
        }
    }
}