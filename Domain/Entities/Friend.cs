using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
   public class Friend
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
    }
}
