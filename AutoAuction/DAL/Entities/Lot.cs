using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoAuction.DAL.Entities
{
    public class Lot
    {
        public int LotId { get; set; }

        public string LotName { get; set; }

        public string LotImageUrl { get; set; }

        public DateTime StarLotSaleDate { get; set; }

        public DateTime EndLotSaleDate { get; set; }

        public decimal StartLotPrice { get; set; }

        public decimal CurrentPrice { get; set; }

        public bool IsSold { get; set; }

        public virtual ICollection<CustomerLot> CustomerLot { get; set; }

        public Lot()
        {
            CustomerLot = new List<CustomerLot>();
        }

    }
}