using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoAuction.DAL.Entities;

namespace AutoAuction.DAL.EFContext
{
    public class AuctionContext : DbContext
    {
        public AuctionContext(string connectionString)
            : base(connectionString)
        {

        }

        public DbSet<Lot> Lots { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRole> CustomerRoles { get; set; }
        public DbSet<CustomerLot> CustomerLots { get; set; }

    }
}