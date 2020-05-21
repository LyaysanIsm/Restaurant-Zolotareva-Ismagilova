using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebSupplier.Models
{
    public class LoginModel
    {
        [Required]
        public string SupplierFIO { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}