using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoAuction.DAL.EFContext;
using AutoAuction.DAL.Entities;
using AutoAuction.DAL.Interfaces;

namespace AutoAuction.DAL.Repositories
{
    public class EFUnitOfWork : IUnitofWork
    {
        private readonly AuctionContext context;    
        private ILotRepository lotRepository;
        private ICustomerRepository customerRepository;
        private ICLRepository clRepository;
        private IRoleRepository roleRepository;    
      
        public EFUnitOfWork(AuctionContext context)
        {
            this.context = context;
        }
        public ICustomerRepository Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(context);
                return customerRepository;
            }
        }

        public ILotRepository Lots
        {
            get
            {
                if (lotRepository == null)
                    lotRepository = new LotRepository(context);
                return lotRepository;
            }
        }

        public ICLRepository CustomerLots
        {
            get
            {
                if (clRepository == null)
                    clRepository = new CLRepository(context);
                return clRepository;

            }
        }
        public IRoleRepository CustomerRoles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(context);
                return roleRepository;
            }
        }       
        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }      

    }
}
