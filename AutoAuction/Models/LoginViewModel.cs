using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoAuction.Models
{
    public class LoginViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int CustomerId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Введите имя")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Введите пароль")]
        public string Password { get; set; }
    }
}