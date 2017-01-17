using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoAuction.DTO
{
    public class CustomerLotDTO
    {
        //Lot      
        public int LotId { get; set; }

        public string LotName { get; set; }
        public string LotImageUrl { get; set; }
       
        public DateTime StarLotSaleDate { get; set; }
        public DateTime EndLotSaleDate { get; set; }
        public decimal StartLotPrice { get; set; }

        public decimal CurrentPrice { get; set; }

        public bool IsSold { get; set; }  

        //CustomerLot
        public decimal CustomerBet { get; set; }

        public bool WinAuction { get; set; }

        public bool LotMaker { get; set; }
    }
}