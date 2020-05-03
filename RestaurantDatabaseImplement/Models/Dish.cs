using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantDatabaseImplement.Models
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]
        public string DishName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("OrderId")]
        public virtual List<Order> Orders { get; set; }
        [ForeignKey("FoodId")]
        public virtual List<DishFood> DishFoods { get; set; }
    }
}
