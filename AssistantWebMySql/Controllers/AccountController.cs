﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AssistantWebMySql.DAL;
using AssistantWebMySql.Interfaces;
using AssistantWebMySql.Migrations;
using AssistantWebMySql.Models;
using AssistantWebMySql.Models.Accounts;
using AssistantWebMySql.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace AssistantWebMySql.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        private readonly IAccountRepository _accountRepository;

        public AccountController()
        {
            _accountRepository = new AccountRepository();
        }

        // GET: /Account/Index
        public ActionResult Index()
        {
            return User.Identity.IsAuthenticated ?
                (ActionResult)View(_accountRepository.GetAllUsers()) : RedirectToAction("Login", "Account");
        }

        // GET: /Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindAsync(model.Email, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);

                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");

                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;

            return View(model);
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return User.Identity.IsAuthenticated ?
                (ActionResult)View() : RedirectToAction("Login", "Account");
        }

        // POST: Account/Register
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
                View("Error");

            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }

                foreach (string error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return View(model);
        }
    }
}