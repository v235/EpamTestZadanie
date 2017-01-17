using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoAuction.DTO
{
    public class UpdateCustomerLotDTO
    {
        //Lot      
        public int LotId { get; set; }
        //CustomerLot
        public decimal CustomerBet { get; set; }
    
    }
}