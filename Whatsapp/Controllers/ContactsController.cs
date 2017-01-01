using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whatsupp.Models;
using Whatsupp.Repositories;

namespace Whatsupp.Controllers
{
    
    public class ContactsController : Controller
    {
        private IContactRepository contactRepository = new DbContactRepository();
        
        public ActionResult Index()
        {
            Account account = (Account)Session["loggedin_account"];
            IEnumerable<Contact> allContacts = contactRepository.GetAllContacts(account.Id);
            return View(allContacts);
        }


        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                Account account = (Account)Session["loggedin_account"];
                contact.OwnerAccId = account.Id;
                contact.ContactAccId = null;
                contactRepository.AddContact(contact);

                return RedirectToAction("Index");
            }

            return View(contact);
        }


        public ActionResult EditContact(int id)
        {
            return View(contactRepository.GetContact(id));
        }

        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactRepository.EditContact(contact);

                return RedirectToAction("Index");
            }

            return View(contact);
        }


        public ActionResult DeleteContact(int id)
        {
            return View(contactRepository.GetContact(id));
        }

        [HttpPost]
        public ActionResult DeleteContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactRepository.DeleteContact(contact);

                return RedirectToAction("Index");
            }

            return View(contact);
        }

        public ActionResult GetAll()
        {
            return View();
        }
    }
}