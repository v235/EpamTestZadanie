using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoAuction.DAL.Entities;
using AutoAuction.DAL.Interfaces;
using AutoAuction.Models;
using AutoMapper;

namespace AutoAuction.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IUnitofWork dataBase;
        public HomeController(IUnitofWork dataBase)
        {
            this.dataBase = dataBase;
        }
        public ActionResult Index()
        {
            var lots = Mapper.Map<IEnumerable<Lot>, IEnumerable<LotViewModel>>(dataBase.Lots.GetAll());
            return View(lots);
        }
    }
}