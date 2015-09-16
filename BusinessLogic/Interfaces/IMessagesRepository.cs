using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Interfaces
{
   public interface IMessagesRepository
    {

        #region Входящие сообщения

        IEnumerable<IncomingMessage> GetIncomingMessages();
        IEnumerable<IncomingMessage> GetIncomingMessagesByUserId(int userId);
        void SaveIncomingMessage(IncomingMessage message);
        void DeleteIncomingMessage(IncomingMessage message);

        #endregion

        #region Исходящие сообщения

        IEnumerable<OutgoingMessage> GetOutgoingMessages();
        IEnumerable<OutgoingMessage> GetOutgoingMessagesByUserId(int userId);
        void SaveOutgoingMessage(OutgoingMessage message);
        void DeleteOutgoingMessage(OutgoingMessage message);

        #endregion
    }
}
