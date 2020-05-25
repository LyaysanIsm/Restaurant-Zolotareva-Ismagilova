using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RestaurantDatabaseImplement.Models
{
    public class RequestFood
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int FoodId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Request Request { get; set; }
        public virtual Food Food { get; set; }
    }
}