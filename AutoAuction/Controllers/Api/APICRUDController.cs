using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoAuction.DAL.Entities;
using AutoAuction.DAL.Interfaces;
using AutoAuction.DTO;
using AutoAuction.Models;
using AutoMapper;

namespace AutoAuction.Controllers.Api
{
     [Authorize]
    public class APICRUDController : ApiController
    {
        private readonly IUnitofWork dataBase;

        public APICRUDController(IUnitofWork dataBase)
        {
            this.dataBase = dataBase;
        }
         public IHttpActionResult Get()
         {                                             
             var customerLots = Mapper.Map<IEnumerable<CustomerLot>, IEnumerable<CustomerLotDTO>>(dataBase.CustomerLots.GetAll(User.Identity.Name));                                
             return Ok(customerLots);
        }

        public IHttpActionResult Get(int id)
        {
            var curcustomerLot = dataBase.CustomerLots.Get(id, User.Identity.Name);

            if (curcustomerLot != null)
            {
                return Ok(Mapper.Map<CustomerLot, CustomerLotDTO>(curcustomerLot));
            }
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] CreateCustomerLotDTO createLot)
        {
            var currentLot = dataBase.Lots.Get(createLot.LotId);
            if (createLot.CustomerBet <= currentLot.CurrentPrice)
                ModelState.AddModelError("CustomerBet",
                    "Ваша ставка должна быть больше текущей!!!");
            var customerCount = dataBase.CustomerLots.GetAll(User.Identity.Name).Where(cl => cl.LotId == createLot.LotId);
            if (customerCount.Count() != 0)
                ModelState.AddModelError("Customer",
                    "Вы уже участвуете в этом аукционе! Для повышения ставки перейдите в 'Мои лоты'");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var customerLot = Mapper.Map<CreateCustomerLotDTO, CustomerLot>(createLot);
            var currentCustomer = dataBase.Customers.GetByName(User.Identity.Name);

            customerLot.Lot = currentLot;
            customerLot.Customer = currentCustomer;
            dataBase.CustomerLots.Create(customerLot);
            currentLot.CurrentPrice = customerLot.CustomerBet;
            dataBase.Lots.Update(currentLot);
            dataBase.Save();
            return Created(new Uri(Request.RequestUri + "/" + customerLot.LotId),createLot);           
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] UpdateCustomerLotDTO updateLot)
        {
            var currentLot = dataBase.CustomerLots.Get(updateLot.LotId, User.Identity.Name);
            if (currentLot.Lot.IsSold)
                ModelState.AddModelError("", "Этот лот уже купили!!!");
            if (updateLot.CustomerBet <= currentLot.Lot.CurrentPrice)
                ModelState.AddModelError("", "Ваша ставка должна быть больше текущей!!!");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            currentLot.CustomerBet = updateLot.CustomerBet;
            dataBase.CustomerLots.Update(currentLot);
            currentLot.Lot.CurrentPrice = updateLot.CustomerBet;
            dataBase.Lots.Update(currentLot.Lot);
            dataBase.Save();
            return Ok(Mapper.Map<CustomerLot, CustomerLotDTO>(currentLot));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (dataBase.CustomerLots.Delete(id, User.Identity.Name))
            {
                dataBase.Save();
                return Ok();
            }
            return BadRequest();
        }
    }
}
