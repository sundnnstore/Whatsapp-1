using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatsupp.Models;

namespace Whatsupp.Repositories
{
    interface IAccountRepository
    {
        Account GetAccount(string email, string password);
        void AddAccount(RegisterModel reg);
    }
}
