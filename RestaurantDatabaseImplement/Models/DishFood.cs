using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RestaurantDatabaseImplement.Models
{
    public class DishFood
    {
        public int Id { get; set; }
        [Required]
        public int Count { get; set; }
        public int FoodId { get; set; }
        public int DishId { get; set; }
        public Food Food { get; set; }
        public Dish Dish { get; set; }
    }
}