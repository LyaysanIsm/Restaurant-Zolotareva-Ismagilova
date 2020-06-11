﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebSupplier.Models
{
    public class RegistrationModel
    {
        [DisplayName("ФИО")]
        [Required(ErrorMessage = "Пожалуйста, введите ФИО")]
        public string SupplierFIO { get; set; }
        [DisplayName("Электронная почта")]
        [Required(ErrorMessage = "Пожалуйста, введите E-Mail")]
        public string Login { get; set; }
        [DisplayName("Пароль")]
        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        public string Password { get; set; }
    }
}