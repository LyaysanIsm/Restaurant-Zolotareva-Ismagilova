using RestaurantBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RestaurantDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public decimal Sum { get; set; }
        public DateTime? CompletionDate { get; set; }
        [Required]
        public Status Status { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}