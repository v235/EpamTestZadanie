using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using AutoAuction.DAL.EFContext;
using AutoAuction.DAL.Entities;
using AutoAuction.DAL.Interfaces;

namespace AutoAuction.DAL.Repositories
{
    public class CLRepository : ICLRepository
    {
        private readonly AuctionContext context;
        public CLRepository(AuctionContext context)
        {
            this.context = context;
        }
        public IEnumerable<CustomerLot> GetAll()
        {
            return context.CustomerLots;
        }
        public IEnumerable<CustomerLot> GetAll(string customerName)
        {
            return context.CustomerLots.Where(cl => cl.Customer.Email == customerName);
        }

        public CustomerLot Get(int id,string customerName)
        {
            return context.CustomerLots.SingleOrDefault(cl => cl.LotId == id&&cl.Customer.Email==customerName);
        }

        public void Create(CustomerLot item)
        {
            context.CustomerLots.Add(item);
        }

        public void Update(CustomerLot item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public bool Delete(int id, string customerName)
        {
            var customerLot = Get(id, customerName);
            if (customerLot != null)
            {
                context.CustomerLots.Remove(customerLot);
                return true;
            }
            return false;
        }
    }
}
