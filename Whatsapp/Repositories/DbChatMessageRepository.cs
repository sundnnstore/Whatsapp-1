using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsupp.Models;

namespace Whatsupp.Repositories
{
    public class DbChatMessageRepository : IChatMessageRepository
    {
        private WhatsUpContext ctx = new WhatsUpContext();

        public void AddChatMessage(ChatMessage chatmessage)
        {
             ctx.ChatMessage.Add(chatmessage);
             ctx.SaveChanges();
        }

        public ChatMessage GetChatMessage(int chatmessageId)
        {
              return ctx.ChatMessage.SingleOrDefault(c => c.Id == chatmessageId);
            return null;
        }

        public IEnumerable<ChatMessage> GetAllChatMessages(int accountId)
        {
            return ctx.ChatMessage.Where(c => (c.RecieverAccId == accountId)).ToList();
        }
    }
}