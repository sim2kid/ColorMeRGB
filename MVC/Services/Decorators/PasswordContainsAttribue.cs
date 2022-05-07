using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Services.Decorators
{
    //Author: Sebastian Pedersen
    //Creation Date: May 4, 2022

    /// <summary>
    /// Decorator used to validate passwords
    /// </summary>

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
AllowMultiple = false, Inherited = true)]
    public class PasswordContainsAttribue : ValidationAttribute
    {
        //Make sure password is valid based on Regex
        //This regex uses matching groups to make sure that the user-entered passwords contain letters, numbers, and symbols.
        //Basically, if there isn't a match, then return false, since it means that the password doesn't contain any:
        //Uppercase letters
        //Lowercase letters
        //Numbers
        //Symbols (i.e. !, @, #, etc.)
        public override bool IsValid(object value)
        {
            if (!Regex.IsMatch((string)value, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).+$"));
            {
                return false;
            }
            return true;
        }
    }
}
