﻿using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Implementations
{
   public class EFFriendRequestsRepository : IFriendRequestsRepository
    {
        private EFDbContext context;
        public EFFriendRequestsRepository(EFDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<FriendRequest> GetFriendRequests()
        {
            return context.FriendRequests;
        }

        public bool RequestIsSent(int userFromId, int userToId)
        {
            return context.FriendRequests.Count(x => x.UserId == userFromId && x.PossibleFriendId == userToId) != 0;
        }

        public void AddFriendRequest(FriendRequest friendRequest)
        {
            context.FriendRequests.Add(friendRequest);
            context.SaveChanges();
        }

        public void DeleteFriendRequest(FriendRequest friendRequest)
        {
            context.FriendRequests.Remove(friendRequest);
            context.SaveChanges();
        }
    }
}
