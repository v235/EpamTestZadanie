using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using System.Web.Security;
using System.Web.UI.WebControls;
using AutoAuction.DAL.Entities;
using AutoAuction.DAL.Interfaces;
using AutoAuction.DTO;
using AutoAuction.Models;
using AutoMapper;

namespace AutoAuction.Controllers
{
    [Authorize]
    public class CRUDController : Controller
    {
        private readonly IUnitofWork dataBase;

        public CRUDController(IUnitofWork dataBase)
        {
            this.dataBase = dataBase;
        }

        // GET: Lot      
        public ActionResult Index()
        {
            var lots = Mapper.Map<IEnumerable<Lot>, IEnumerable<LotViewModel>>(dataBase.Lots.GetAll());
            if (Roles.IsUserInRole("admin"))
                return View("AdminIndex", lots);
            return View(lots);
        }

        //GET: Lot/id    
        public ActionResult AddCustomerToLot(int id)
        {
            if (Roles.IsUserInRole("admin"))
                return RedirectToAction("UpdateLot", "CRUD", new {id});
            var lot = Mapper.Map<Lot, CustomerLotViewModel>(dataBase.Lots.Get(id));
            if (lot == null)
                return new HttpNotFoundResult();
            return View(lot);
        }

        [AllowAnonymous]
        public ActionResult CustomerSeeLot(int id)
        {
            var lot = Mapper.Map<Lot, CustomerLotViewModel>(dataBase.Lots.Get(id));
            if (lot == null)
                return new HttpNotFoundResult();
            return View(lot);
        }

        public ActionResult AddNewLot()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLotViewModel createLot, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    uploadImage.SaveAs(
                        Server.MapPath("~/Content/Image/" + System.IO.Path.GetFileName(uploadImage.FileName)));
                    createLot.LotImageUrl =
                        "/Content/Image/" + System.IO.Path.GetFileName(uploadImage.FileName);
                }
                var lot = Mapper.Map<CreateLotViewModel, Lot>(createLot);
                lot.StarLotSaleDate = DateTime.Today;
                lot.CurrentPrice = lot.StartLotPrice;
                lot.IsSold = false;
                var currentCustomer = dataBase.Customers.GetByName(User.Identity.Name);             
                CustomerLot customerLot = new CustomerLot()
                {
                    Lot = lot,
                    LotId = lot.LotId,
                    Customer = currentCustomer,
                    CustomerId = currentCustomer.CustomerId,
                    CustomerBet = 0,
                    LotMaker = true,
                    WinAuction = false
                };
                dataBase.CustomerLots.Create(customerLot);
                dataBase.Save();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ModelState.AddModelError("", "Данные введены некоректно. Пожалуйства исправте ошибки!");
            }
            return View("AddNewLot", createLot);
        }

        public ActionResult UpdateLot(int id)
        {
            var lotToUpdate = Mapper.Map<Lot, UpdateLotViewModel>(dataBase.Lots.Get(id));
            return View(lotToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateLotViewModel updateLot, HttpPostedFileBase uploadImage,string action)
        {
            switch (action)
            {
                case "delete":
                    dataBase.Lots.Delete(updateLot.LotId);
                    break;          
                case "update":
                    var lotInDb = dataBase.Lots.Get(updateLot.LotId);
                    if (lotInDb == null)
                        return new HttpNotFoundResult();
                    if (lotInDb.CurrentPrice <= updateLot.StartLotPrice)
                        ModelState.AddModelError("StartLotPrice", "Начальная цена не может быть больше текущей ставки");
                    if (ModelState.IsValid)
                    {
                        if (uploadImage != null)
                        {
                            uploadImage.SaveAs(
                                Server.MapPath("~/Content/Image/" + System.IO.Path.GetFileName(uploadImage.FileName)));
                            updateLot.LotImageUrl =
                                "/Content/Image/" + System.IO.Path.GetFileName(uploadImage.FileName);
                        }
                        var lot = Mapper.Map<UpdateLotViewModel, Lot>(updateLot);
                        lotInDb.LotName = lot.LotName;
                        lotInDb.LotImageUrl = lot.LotImageUrl;
                        lotInDb.EndLotSaleDate = lot.EndLotSaleDate;
                        lotInDb.StartLotPrice = lot.StartLotPrice;
                        //update current price!!!
                        dataBase.Lots.Update(lotInDb);
                        break;
                    }
                    ModelState.AddModelError("", "Данные введены некоректно. Пожалуйства исправте ошибки!");
                    return View("UpdateLot", updateLot);
            }
            dataBase.Save();
            return RedirectToAction("Index", "Customer");                   
        }     
    }
}