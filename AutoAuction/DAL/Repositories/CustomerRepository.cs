using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoAuction.DAL.EFContext;
using AutoAuction.DAL.Entities;
using AutoAuction.DAL.Interfaces;

namespace AutoAuction.DAL.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly AuctionContext context;
        public CustomerRepository(AuctionContext context)
        {
            this.context = context;
        }      
        public Customer GetByName(string customerName)
        {
            return context.Customers.FirstOrDefault(c => c.Email == customerName);
        }

        public Customer GetByNameAndPassword(string customerName, string customerPassword)
        {
            return context.Customers.FirstOrDefault(c => c.Email == customerName && c.Password == customerPassword);
        }
        public void Create(Customer item)
        {
            context.Customers.Add(item);
        }
       
    }
}
