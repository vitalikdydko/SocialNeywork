﻿using BusinessLogic;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Filters;

namespace Web.Controllers
{
    [Culture]
    public class SearchController : Controller
    {
         private DataManager dataManager;
        public SearchController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string firstName, string secondName, string middleName)
        {
            IEnumerable<User> model= dataManager.Users.GetUsers().Where(x =>
                    x.FirstName.ToLowerInvariant().StartsWith(firstName.ToLowerInvariant()) &&
                    x.SecondName.ToLowerInvariant().StartsWith(secondName.ToLowerInvariant()) &&
                    x.MiddleName.ToLowerInvariant().StartsWith(middleName.ToLowerInvariant()));

            return View(model);
        }

    }
}
