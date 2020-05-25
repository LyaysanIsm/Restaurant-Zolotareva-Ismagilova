using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantDatabaseImplement.Models
{
    public class Food
    {
        public int Id { get; set; }
        [Required]
        public string FoodName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("FoodId")]
        public virtual List<FridgeFood> FridgeFoods { get; set; }
        [ForeignKey("FoodId")]
        public virtual List<RequestFood> RequestFoods { get; set; }
    }
}