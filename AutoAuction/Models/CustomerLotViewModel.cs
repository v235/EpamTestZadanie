using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoAuction.Models
{
    public class CustomerLotViewModel
    {
        [HiddenInput]
        public int LotId { get; set; }

        public string LotName { get; set; }
        public string LotImageUrl { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime StarLotSaleDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime EndLotSaleDate { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal StartLotPrice { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal CurrentPrice { get; set; }

        public bool IsSold { get; set; }  
        //CustomerLot
        [Required(ErrorMessage = "Введите свою ставку")]
        [Display(Name = "Укажите свою ставку")]
        [DataType(DataType.Currency, ErrorMessage = "Корректно введите цену")]
        public decimal CustomerBet { get; set; }

        public bool WinAuction { get; set; }

        public bool LotMaker { get; set; }
    }
}