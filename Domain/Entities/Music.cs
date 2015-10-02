using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
   public class Music
    {
        public int Id { get; set; }
        public string File { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
