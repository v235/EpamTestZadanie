using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using AutoAuction.DAL.EFContext;
using AutoAuction.DAL.Entities;
using AutoAuction.DAL.Interfaces;

namespace AutoAuction.DAL.Repositories
{
    public class LotRepository : ILotRepository
    {
        private readonly AuctionContext context;

        public LotRepository(AuctionContext context)
        {
            this.context = context;
        }

        public IEnumerable<Lot> GetAll()
        {
            return context.Lots.Where(l => l.IsSold == false);
        }

        public Lot Get(int id)
        {
            return context.Lots.Find(id);
        }

        public void Create(Lot item)
        {
            context.Lots.Add(item);          
        }

        public void Update(Lot item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var lot = context.Lots.Find(id);
            if (lot != null)
                context.Lots.Remove(lot);

        }
    }
}
