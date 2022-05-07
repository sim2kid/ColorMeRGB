using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Decorators;

namespace Services.Models
{
    //Author: Sebastian Pedersen
    //Creation Date: May 4, 2022
    public  class UserModel
    {
        public Guid Id { get; set; }

        [StringSizeAttribute(3, 20, ErrorMessage ="Username must be no shorter than 3 characters and no longer than 20")]
        public string UserName { get; set; }

        [PasswordContainsAttribue(ErrorMessage = "Password must contain at least 1 lowercase, 1 uppercase, 1 symbol ('# ? ! @ $ % ^ & * -'), and 1 number")]
        [StringSizeAttribute(9, 40, ErrorMessage ="Password must be no shorter than 9 characters and no longer than 40")]
        public string Password { get; set; }

        public string Salt { get; set; }

        public DateTime SignUpTime { get; set; }
    }
}
