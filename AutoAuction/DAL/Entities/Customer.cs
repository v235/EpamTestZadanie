using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoAuction.DAL.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public CustomerRole Role { get; set; }
        public virtual ICollection<CustomerLot> CustomerLot { get; set; }
        public Customer()
        {
            CustomerLot = new List<CustomerLot>();
        }
    }
}