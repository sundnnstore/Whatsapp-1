using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsupp.Models;
using System.Data.Entity;

namespace Whatsupp.Repositories
{
    public class DbContactRepository : IContactRepository
    {
        private WhatsUpContext ctx = new WhatsUpContext();

        public void AddContact(Contact contact)
        {
            ctx.Contacts.Add(contact);
            ctx.SaveChanges();
        }

        public void DeleteContact(Contact contact)
        {
            Contact dbContact = ctx.Contacts.Find(contact.Id);
            if (dbContact != null)
            {
                ctx.Contacts.Remove(contact);
                ctx.SaveChanges();
            }
        }

        public void EditContact(Contact contact)
        {
            Contact dbContact = ctx.Contacts.SingleOrDefault(c => c.Id == contact.Id);
            if (dbContact != null)
            {
                dbContact.Name = contact.Name;
                dbContact.Email = contact.Email;
                ctx.SaveChanges();
            }
        }
        
        public IEnumerable<Contact> GetAllContacts(int accountId)
        {
            return ctx.Contacts.Where(c => (c.OwnerAccId == accountId)).ToList();
        }

        public Contact GetContact(int contactId)
        {
            return ctx.Contacts.SingleOrDefault(c => c.Id == contactId);
        }
    }
}