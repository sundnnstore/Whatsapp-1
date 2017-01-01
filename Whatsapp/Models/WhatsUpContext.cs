using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public class WhatsUpContext : DbContext
    {
        public WhatsUpContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ChatMessage> ChatMessage { get; set; }
    }
}