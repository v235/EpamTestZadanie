using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoAuction.Models
{
    public class CreateLotViewModel
    {    
        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя лота")]
        [StringLength(20)]
        public string LotName { get; set; }

        [Display(Name = "Изображение лота")]
        public string LotImageUrl { get; set; }

        [Required(ErrorMessage = "Выберите дату окончания продаж")]
        [Display(Name = "Дата окончания продаж")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode=true)]
        public DateTime EndLotSaleDate { get; set; }

        [Required(ErrorMessage = "Введите стартовую цену лота")]
        [Display(Name = "Стартовая цена")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public decimal StartLotPrice { get; set; }
   
    }   
}