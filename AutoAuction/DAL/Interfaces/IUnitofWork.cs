using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoAuction.DAL.EFContext;
using AutoAuction.DAL.Entities;

namespace AutoAuction.DAL.Interfaces
{
    public interface IUnitofWork 
    {
        ICustomerRepository Customers { get; }
        ILotRepository Lots { get; }
        ICLRepository CustomerLots { get; }
        IRoleRepository CustomerRoles { get; }
        void Save();
        void Dispose();
    }
}
