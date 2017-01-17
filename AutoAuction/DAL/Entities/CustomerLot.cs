using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoAuction.DAL.Entities
{
    public class CustomerLot
    {
        [Key, Column(Order = 0)]
        public int CustomerId { get; set; }

        [Key, Column(Order = 1)]
        public int LotId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Lot Lot { get; set; }
        public decimal CustomerBet { get; set; }
        public bool WinAuction { get; set; }
        public bool LotMaker { get; set; }

    }
}