using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Validators
{
    public class Age :ValidationAttribute
    {
        public int MinimumAge { get; private set; }

        public Age(int minimumAge)
        {
            this.MinimumAge = minimumAge;
        }
       
        public override bool IsValid(object value)
        {
            if (value is DateTime)
            {
                return DateTime.Now.AddYears(-this.MinimumAge) <= (DateTime)value;
            }
            else
                throw new ArgumentException("le type doit être un DateTime");
        }
    }
}