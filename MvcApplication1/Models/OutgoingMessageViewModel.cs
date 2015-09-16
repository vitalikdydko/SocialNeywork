using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class OutgoingMessageViewModel
    {
        //Исходящее сообщение
        public OutgoingMessage Message { get; set; }

        //Адресат
        public User UserTo { get; set; }
    }
}