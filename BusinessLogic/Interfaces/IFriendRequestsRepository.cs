using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Interfaces
{
   public interface IFriendRequestsRepository
    {
        IEnumerable<FriendRequest> GetFriendRequests();
        //Проверяем, отправил ли пользователь1 пользователю2 запрос на дружбу
        bool RequestIsSent(int userFromId, int userToId);
        void AddFriendRequest(FriendRequest friendRequest);
        void DeleteFriendRequest(FriendRequest friendRequest);
    }
}
