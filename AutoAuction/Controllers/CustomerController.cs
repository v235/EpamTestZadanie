using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AutoAuction.Controllers
{
     [Authorize]
    public class CustomerController : Controller
    {
         // GET: Customer
        public ActionResult Index()
        {
            if (Roles.IsUserInRole("admin"))
                return RedirectToAction("Index", "CRUD");
            return View();
        }
    }
}