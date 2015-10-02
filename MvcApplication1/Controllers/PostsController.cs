using BusinessLogic;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    public class PostsController : ApiController
    {
        private EFDbContext _ctx;
        public PostsController()
        {
            this._ctx = new EFDbContext();
        }

        // GET api/<controller>
        public IEnumerable<Post> Get()
        {
            return this._ctx.Posts.OrderByDescending(x => x.DatePosted).ToList();
        }
    }
}