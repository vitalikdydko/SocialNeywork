using BusinessLogic;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ImageController : Controller
    {
        private DataManager dataManager;
        public ImageController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

     //   EFDbContext context = new EFDbContext();
       
        public FileContentResult GetImage(int picId)
        {
            Picture picture = dataManager.Pictures.GetPictures

                .FirstOrDefault(g => g.Id == picId);

            if (picture != null)
            {
                return File(picture.ImageData, picture.ImageMineType);
            }
            else
            {
                return null;
            }
        }


    }
}
