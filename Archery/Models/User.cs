﻿using Archery.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public abstract class User:BaseModel

    {
        

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [StringLength(150, ErrorMessage = "Le champ {0} doit contenir {1} caractères max.")]
        [Display(Name = "Adresse mail")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
            , ErrorMessage = "le format n'est pas bon.")]
        [Email(ErrorMessage ="Un compte utilisant cette adresse mail existe déjà.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$"
        , ErrorMessage = "{0} incorrect")]
        [StringLength(150)]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La confirmation n'est pas bonne.")]
        public string ConfirmedPassword { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [Display(Name = "Nom")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [Display(Name = "Prénom")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [Age(9, MaximumAge=90,ErrorMessage = " Pour le champ {0}, vous devez avoir plus de {1} an")]
        [Column(TypeName ="datetime2")]
        public DateTime BirthDate { get; set; }


    }
}