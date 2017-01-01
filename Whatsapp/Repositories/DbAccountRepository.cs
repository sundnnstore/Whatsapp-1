using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsupp.Models;

namespace Whatsupp.Repositories
{
    public class DbAccountRepository : IAccountRepository
    {
        private WhatsUpContext ctx = new WhatsUpContext();

        public void AddAccount(RegisterModel reg)
        {
            Account acc = new Account();
            acc.Name = reg.Name;
            acc.Email = reg.Email;
            acc.Password = reg.Password;
            ctx.Accounts.Add(acc);
            ctx.SaveChanges();
        }

        public Account GetAccount(string email, string password)
        {
            Account acc = ctx.Accounts.SingleOrDefault(c => c.Email == email && c.Password == password);
            return acc;
        }
    }
}