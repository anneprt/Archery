﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public abstract class User
    {
        public int Id { get; set; }

        [Display(Name = "Adresse mail")]
        public string Mail { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }

        [Display(Name ="Nom")]
        public string LastName { get; set; }

        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


    }
}