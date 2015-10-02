using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IMusicRepository
    {

        IEnumerable<Music> PicturesByUserId(int userId);
        IQueryable<Music> GetPictures { get; }
        void SaveMusic(Music music);
    }
}
