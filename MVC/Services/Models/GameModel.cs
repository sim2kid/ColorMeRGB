using Services.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    //Author: Sebastian Pedersen
    //Creation Date: May 4, 2022
    public class GameModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [StringSizeAttribute(6, 6)]
        public string AnswerColor { get; set; }

        public DateTime Timestamp { get; set; }

        public bool Completed { get; set; }
    }
}
