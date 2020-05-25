using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestaurantDatabaseImplement.Models
{
    public class Fridge
    {
        public int Id { get; set; }
        [Required]
        public string FridgeName { get; set; }
        [Required]
        public int Capacity { get; set; }
        public string Type { get; set; }
        [ForeignKey("FridgeID")]
        public virtual List<FridgeFood> FridgeFoods { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}