using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery
{
    public class Validation : ValidationAttribute

    {
        public int years;

       public void OldEnough(int years)
        {
            this.years = years;
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime)
            {
                DateTime date = (DateTime)value;
                return date.AddYears(this.years) <= DateTime.Now;
            }
            return false;
        }
    }
}