using BusinessLogic;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        private DataManager dataManager;
        public ImageController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        
        public ActionResult Index()
        { //Подготовляваем картинки кожного користувача
            List<PictureModel> model = new List<PictureModel>();
            foreach (Picture picture in dataManager.Pictures.PicturesByUserId((int)Membership.GetUser().ProviderUserKey))
            {
                model.Add(new PictureModel
                {
                    File = picture.File,
                   
                });
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateImage()
        {
                    
            return View();

        }

        [HttpPost]
        public ActionResult CreateImage(Picture picture, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {

                if (file != null)
                {
                                   
                    // Получаем имя файла
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    // сохраняем файл по определенному пути на сервере
                    string physicalPath = Server.MapPath("~/Files/foto/" + ImageName);
                    //сохраняэм файл в папку
                    file.SaveAs(physicalPath);
                    //получаем id користувача
                    var id = Membership.GetUser().ProviderUserKey;
                    Picture newRecord = new Picture();
               
                    newRecord.UserId =(int) id;
                    newRecord.File = ImageName;
                    dataManager.Pictures.SavePicture(newRecord);

                }
            

                return RedirectToAction("Index","Home");
            }
            return View(picture);


        }

        
    }
}
