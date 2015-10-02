using BusinessLogic;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class MusicController : Controller
    {
         private DataManager dataManager;
        public MusicController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        
        public ActionResult Index()
        { //Подготовляваем картинки кожного користувача
            List<MusicModel> model = new List<MusicModel>();
            foreach (Music music in dataManager.Musics.PicturesByUserId((int)Membership.GetUser().ProviderUserKey))
            {
                model.Add(new MusicModel
                {
                    File = music.File,
                   
                });
                ViewBag.Name = music.File;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateMusic()
        {
                    
            return View();

        }

        [HttpPost]
        public ActionResult CreateMusic(Music music, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {

                if (file != null)
                {
                                   
                    // Получаем имя файла
                    string MusicName = System.IO.Path.GetFileName(file.FileName);
                    ViewBag.Name = MusicName;
                    // сохраняем файл по определенному пути на сервере
                    string physicalPath = Server.MapPath("~/Files/music/" + MusicName);
                    //сохраняэм файл в папку
                    file.SaveAs(physicalPath);
                    //получаем id користувача
                    var id = Membership.GetUser().ProviderUserKey;
                    Music newRecord = new Music();
               
                    newRecord.UserId =(int) id;
                    newRecord.File = MusicName;
                    dataManager.Musics.SaveMusic(newRecord);

                }
            

                return RedirectToAction("Index","Home");
            }
            return View(music);


        }

    }
}
