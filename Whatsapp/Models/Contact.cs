using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public class Contact
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of contact is required")]
        [Display(Name = "Contact Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Emailaddress of contact is required")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public int OwnerAccId { get; set; }

        public int? ContactAccId { get; set; }

        //...

        public Contact()
        {
            //...
        }

        public Contact(int id, string name, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
        }

        public Contact(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }
}