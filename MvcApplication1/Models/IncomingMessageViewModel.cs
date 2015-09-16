using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class IncomingMessageViewModel
    {
        //Входящее сообщение
        public IncomingMessage Message { get; set; }

        //Автор
        public User UserFrom { get; set; }
    }
}