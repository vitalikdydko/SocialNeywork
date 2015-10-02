using BusinessLogic.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Domain.Entities;

namespace BusinessLogic.Implementations
{
   public class EFPostRepository:IPostRepository
    {
         private EFDbContext context;
        public EFPostRepository(EFDbContext context)
        {
            this.context = context;
        }

        public Post GetPostById(int id)
        {
            return context.Posts.FirstOrDefault(x => x.Id == id);
        }

        public void SavePost(Post post)
{
 	if (post.Id == 0)
                context.Posts.Add(post);
            else
                context.Entry(post).State = EntityState.Modified;
            context.SaveChanges();
        }
}
}


     
