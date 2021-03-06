﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IPictureRepository
    {
         IEnumerable<Picture> PicturesByUserId(int userId);
        IQueryable<Picture> GetPictures{get;}
       void SavePicture(Picture picture);
    }
}
