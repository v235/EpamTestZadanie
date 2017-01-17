using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoAuction.DAL.Entities;
using AutoAuction.DAL.Interfaces;
using AutoAuction.DTO;
using AutoAuction.Models;
using AutoMapper;

namespace AutoAuction.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUnitofWork dataBase;
        public AccountController(IUnitofWork dataBase)
        {
            this.dataBase = dataBase;
        }
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var customer = Mapper.Map<LoginViewModel, Customer>(loginViewModel);
                var customerInDb = dataBase.Customers.GetByNameAndPassword(customer.Email, customer.Password);
                if (customerInDb != null)
                {
                    FormsAuthentication.SetAuthCookie(loginViewModel.Email, true);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }                
            }
            return View(loginViewModel);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = Mapper.Map<RegisterViewModel, Customer>(registerViewModel);
                var customerInDb = dataBase.Customers.GetByName(customer.Email);
                if (customerInDb == null)
                {
                    customer.RoleId = RegisterViewModel.customerRole;
                    dataBase.Customers.Create(customer);
                    dataBase.Save();
                    FormsAuthentication.SetAuthCookie(registerViewModel.Email, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь с таким логином уже существует");
            }
            return View(registerViewModel);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}