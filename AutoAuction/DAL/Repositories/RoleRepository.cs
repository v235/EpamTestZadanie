using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoAuction.DAL.EFContext;
using AutoAuction.DAL.Entities;
using AutoAuction.DAL.Interfaces;

namespace AutoAuction.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AuctionContext context;
        public RoleRepository(AuctionContext context)
        {
            this.context = context;
        }       
        public CustomerRole Get(int id)
        {
            return context.CustomerRoles.Find(id);
        }

        public void Create(CustomerRole item)
        {
            context.CustomerRoles.Add(item);
        }
    }
}
