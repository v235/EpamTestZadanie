using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoAuction.DAL.Entities;

namespace AutoAuction.DAL.Interfaces
{
    public interface IRoleRepository
    {
        CustomerRole Get(int id);
        void Create(CustomerRole item);
    }
}
