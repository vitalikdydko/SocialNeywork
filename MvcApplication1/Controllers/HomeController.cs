﻿using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Models;
using Domain.Entities;
using Web.Filters;

namespace Web.Controllers
{
    [Authorize]
    [Culture]
    public class HomeController : Controller
    {
        
        private DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public ActionResult Partial()
        {
           
            return PartialView();
        }
        
        public ActionResult Index(int id=0)
        {

            //Если в адресе Url не был представлен Id пользователя, то явным образом вычисляем этот Id и
            //перенаправляем пользователя на то же действие, однако добавляем в адрес вычисленный Id
            if (id == 0)
                return RedirectToAction("Index", new { id = Membership.GetUser().ProviderUserKey });

            User user = dataManager.Users.GetUserById(id);

            //Исходя из значения Id в адресе Url определяем, на чью страницу мы попали
            UserViewModel model = new UserViewModel
            {
                UserPage = user,
                UserIsMe = id == (int)Membership.GetUser().ProviderUserKey,
                UserIsMyFriend =
                    dataManager.Friends.UsersAreFriends(
                        (int)Membership.GetUser().ProviderUserKey, user.Id),
                FriendRequestIsSent =
                    dataManager.FriendRequests.RequestIsSent(user.Id,
                                                             (int)
                                                             Membership.GetUser().
                                                                 ProviderUserKey)
            };
            return View(model);
        }


      

    }
}
