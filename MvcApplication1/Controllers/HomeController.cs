using BusinessLogic;
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


        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            List<string> cultures = new List<string>() { "ru", "en", "de" };
            if (!cultures.Contains(lang))
            {
                lang = "ru";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {

                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

    }
}
