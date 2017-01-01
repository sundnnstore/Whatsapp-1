using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Whatsupp.Repositories;
using Whatsupp.Models;

namespace Whatsupp.Controllers
{
    public class AccountController : Controller
    {
        IAccountRepository repository = new DbAccountRepository();

        public AccountController()
        {
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Account account = repository.GetAccount(model.Email, model.Password);
                if (account != null)
                {
                    FormsAuthentication.SetAuthCookie(account.Email, false);

                    // remember complete account
                    Session["loggedin_account"] = account;

                    // redirect to default entry of Chats controller
                    return RedirectToAction("Index", "Chats");
                }
                else
                {
                    ModelState.AddModelError("login-error", "The user name of password provided is incorrect.");
                }
            }
            // there was an error, go back to Login page
            return View(model);
        }

        public ActionResult LogOff()
        {
            if (Session["loggedin_account"] == null)
                ViewData["bool"] = false;
            else
                ViewData["bool"] = true;
            return View();
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();

            // redirect to Login of Account controller
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel reg)
        {
            if (ModelState.IsValid)
            {
                repository.AddAccount(reg);
                return RedirectToAction("Index", "Home");
            }
            return View(reg);
        }
    }
}