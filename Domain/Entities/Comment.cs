using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
   public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }       
        public DateTime DatePosted { get; set; }
        public virtual Post ParentPost { get; set; }
    }
}
