using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoAuction.DAL.Entities;

namespace AutoAuction.DAL.Interfaces
{
    public interface ILotRepository
    {
        IEnumerable<Lot> GetAll();
        Lot Get(int id);
        void Create(Lot item);
        void Update(Lot item);
        void Delete(int id);
    }
}
