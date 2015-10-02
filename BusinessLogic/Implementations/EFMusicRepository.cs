using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Implementations
{
   public class EFMusicRepository:IMusicRepository
    {
        private EFDbContext context;
        public EFMusicRepository(EFDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Music> PicturesByUserId(int userId)
        {
            return context.Musics.Where(x => x.UserId == userId);
        }

        public IQueryable<Music> GetPictures
        {
            get { return context.Musics; }
        }

        public void SaveMusic(Music music)
        {
            if (music.Id == 0)
            {
                context.Musics.Add(music);
            }
            else
            {
                Picture dbEntry = context.Pictures.Find(music.Id);
                if (dbEntry != null)
                {

                    dbEntry.File = music.File;
                }

            }
            context.SaveChanges();
        }
    }
}
