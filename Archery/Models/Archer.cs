using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class Archer : User
    {
        [Display(Name ="Numéro de licence")]
        [StringLength(15)]
        public string LicenseNumber { get; set; }

    }
}