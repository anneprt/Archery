using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public abstract class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Le champ {0} est obligatoire.")]
        [StringLength(150, ErrorMessage ="Le champ {0} doit contenir {1} caractères max.")]
        [Display(Name = "Adresse mail")]
        [RegularExpression(@""
            ,ErrorMessage ="le format n'est pas bon.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="La confirmation n'est pas bonne.")]
        public string ConfirmedPassword { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [Display(Name ="Nom")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


    }
}