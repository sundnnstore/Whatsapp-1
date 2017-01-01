using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public class ChatMessage
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public int SenderAccId { get; set; }

        public int RecieverAccId { get; set; }

        public ChatMessage()
        {
            //..
        }

        public ChatMessage(int id, string message)
        {
            this.Id = id;
            this.Message = message;
            this.Time = DateTime.Now;
        }
    }
}