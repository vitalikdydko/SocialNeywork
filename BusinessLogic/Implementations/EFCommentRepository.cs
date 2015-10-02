using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Domain;
using System.Data.Entity;

namespace BusinessLogic.Implementations
{
    public class EFCommentRepository : ICommentRepository
    {
        private EFDbContext context;
        public EFCommentRepository(EFDbContext context)
        {
            this.context = context;
        }

        public void SaveComment(Comment comment)
        {
            if (comment.Id == 0)
                context.Comments.Add(comment);
            else
                context.Entry(comment).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
    }

