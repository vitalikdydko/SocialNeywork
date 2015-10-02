using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
   public interface IPostRepository
    {
        Post GetPostById(int id);
        void SavePost(Post post);
    }
}
