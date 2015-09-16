using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
   public class OutgoingMessage
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserToId { get; set; }
        [Required(ErrorMessage = "*")]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
