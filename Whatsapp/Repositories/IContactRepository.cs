using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatsupp.Models;

namespace Whatsupp.Repositories
{
    interface IContactRepository
    {
        IEnumerable<Contact> GetAllContacts(int accountId);
        Contact GetContact(int contactId);
        void AddContact(Contact contact);
        void EditContact(Contact contact);
        void DeleteContact(Contact contact);
    }
}
