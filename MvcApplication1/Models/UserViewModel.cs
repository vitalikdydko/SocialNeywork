using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserViewModel
    {

        //Пользователь
        public User UserPage { get; set; }

        //Вызываемый пользователь - это я сам
        public bool UserIsMe { get; set; }

        //Этот пользователь - мой друг
        public bool UserIsMyFriend { get; set; }

        //Я уже отправил этому пользователю заявку в друзья
        public bool FriendRequestIsSent { get; set; }
        public Picture UserPicture { get; set; }
    }
}