using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Services.Decorators
{
    //Author: Sebastian Pedersen
    //Creation Date: May 4, 2022

    /// <summary>
    /// Decorator used to check the length of strings
    /// Can be used to validate usernames as well as other relevant data
    /// </summary>

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
AllowMultiple = false, Inherited = true)]
    public class StringSizeAttribute : ValidationAttribute
    {
        //Minimum length of a string
        public int MinLength { get; set; }
        //maximum length of a string
        public int MaxLength { get; set; }

        //Make sure string is valid based on requirements
        public override bool IsValid(object value)
        {
            if (value == null || value is not string || ((string)value).Length > MaxLength || ((string)value).Length < MinLength || !((string)value).All(char.IsLetterOrDigit))
            {
                return false;
            }
            return true;
        }
    }
}
