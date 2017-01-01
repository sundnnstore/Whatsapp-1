using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatsupp.Models;

namespace Whatsupp.Repositories
{
    interface IChatMessageRepository
    {
        ChatMessage GetChatMessage(int chatmessageId);
        void AddChatMessage(ChatMessage chatmessage);
        IEnumerable<ChatMessage> GetAllChatMessages(int accountId);
    }
}
