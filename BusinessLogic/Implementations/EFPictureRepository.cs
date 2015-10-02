using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BusinessLogic.Implementations
{
    public class EFPictureRepository : IPictureRepository
    {
        private EFDbContext context;
        public EFPictureRepository(EFDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Picture> PicturesByUserId(int userId)
        {
            return context.Pictures.Where(x => x.UserId == userId);
        }
        public IQueryable<Picture> GetPictures
        {
            get { return context.Pictures; }
        }
        public void SavePicture(Picture picture)
        {
            if (picture.Id == 0)
            {
                context.Pictures.Add(picture);
            }
            else
            {
                Picture dbEntry = context.Pictures.Find(picture.Id);
                if (dbEntry != null)
                {
                  
                    dbEntry.File = picture.File;
                }

            }
            context.SaveChanges();
        }
    }
}
