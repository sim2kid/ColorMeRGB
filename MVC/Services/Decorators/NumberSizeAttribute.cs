using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Decorators
{
    //Author: Sebastian Pedersen
    //Creation Date: May 5, 2022

    /// <summary>
    /// This is mainly used to make sure that the RGB guesses
    /// don't go above 255 or below 0.
    /// </summary>

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
AllowMultiple = false, Inherited = true)]
    public class NumberSizeAttribute : ValidationAttribute
    {
        //Minimum length of a number
        public int MinSize { get; set; }
        //maximum length of a number
        public int MaxSize { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null || value is not int || ((int)value) > MaxSize || ((int)value) < MinSize)
            {
                return false;
            }
            return true;
        }
    }
}
