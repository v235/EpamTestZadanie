using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoAuction.DAL.Entities;

namespace AutoAuction.DAL.Interfaces
{
    public interface ICLRepository
    {
        IEnumerable<CustomerLot> GetAll();
        IEnumerable<CustomerLot> GetAll(string customerName);
        CustomerLot Get(int id, string customerName);
        void Create(CustomerLot item);
        void Update(CustomerLot item);
        bool Delete(int id,string customerName);
    }
}
