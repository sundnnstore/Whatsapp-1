using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public class Account
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of account is required!")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail of account is required!")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password of account is required!")]
        public string Password { get; set; }

        public Account()
        {
            //..
        }

        public Account(int id, string name, string email, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
    }
}