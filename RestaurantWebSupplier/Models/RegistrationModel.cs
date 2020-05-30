using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebSupplier.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Пожалуйста, введите ФИО")]
        public string SupplierFIO { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите пароль")]        
        [StringLength(25, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите E-Mail")]       
        public string Login { get; set; }
    }
}