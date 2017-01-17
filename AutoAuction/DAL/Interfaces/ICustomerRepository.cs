using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoAuction.DAL.Entities;

namespace AutoAuction.DAL.Interfaces
{
    public interface ICustomerRepository 
    {      
        Customer GetByName(string name);
        Customer GetByNameAndPassword(string customerName, string customerPassword);
        void Create(Customer item);
    }
}
