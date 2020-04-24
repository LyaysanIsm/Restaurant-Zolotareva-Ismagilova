using RestaurantBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class Order
    {
        public int? ID { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Amount { get; set; }
        public DateTime CompletionDate { get; set; }
        public Status Status { get; set; }
        public int DishId { get; set; }
    }
}
