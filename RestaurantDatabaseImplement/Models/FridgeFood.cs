using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RestaurantDatabaseImplement.Models
{
    public class FridgeFood
    {
        public int Id { get; set; }
        public int FridgeId { get; set; }
        public int FoodId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Reserved { get; set; }
        public virtual Fridge Fridge { get; set; }
        public virtual Food Food { get; set; }
    }
}