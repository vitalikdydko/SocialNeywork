using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
   public interface ICommentRepository
    {
        void SaveComment(Comment comment);
    }
}
