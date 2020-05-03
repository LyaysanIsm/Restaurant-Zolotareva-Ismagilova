using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestaurantDatabaseImplement.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public int FridgeId { get; set; }
        [Required]
        public string SupplierFIO { get; set; }
        [Required]
        public int Password { get; set; }
    }
}