using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whatsupp.Models;
using Whatsupp.Repositories;

namespace Whatsupp.Controllers
{
    public class ChatsController : Controller
    {
        private IChatMessageRepository chatRepository = new DbChatMessageRepository();
        
        public ActionResult Index()
        {
            Account account = (Account)Session["loggedin_account"];
            IEnumerable<ChatMessage> lastchatmessages = GetLastFiveChatMessages();
            return View(lastchatmessages);
        }

        public ActionResult AddMessage(int recieverId)
        {
            Account senderaccount = (Account)Session["loggedin_account"];
            ChatMessage mess = new ChatMessage();
            mess.SenderAccId = senderaccount.Id;
            mess.RecieverAccId = recieverId;
            return View(mess);
        }

        [HttpPost]
        public ActionResult AddMessage(ChatMessage mess)
        {
            chatRepository.AddChatMessage(mess);
            return RedirectToAction("Index");
        }

        public IEnumerable<ChatMessage> GetLastFiveChatMessages()
        {
            //get all messages
            Account account = (Account)Session["loggedin_account"];
            IEnumerable<ChatMessage> old2chatmessages = chatRepository.GetAllChatMessages(account.Id);
            //ienumerable to list zodat ik ze kan sorteren
            List<ChatMessage> oldmessages = old2chatmessages.ToList();
            List<ChatMessage> newmessages = new List<ChatMessage>();
            int counti = oldmessages.Count;
            if (counti > 5)
            {
                for (int i = 1; i <= 5; i++)
                    newmessages.Add(oldmessages[counti - i]);
                return newmessages;
            }
            else
            {
                for (int i = 1; i <= counti; i++)
                    newmessages.Add(oldmessages[counti - i]);
                return newmessages;
            }
        }
    }
}