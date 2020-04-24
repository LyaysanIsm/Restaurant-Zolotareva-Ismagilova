using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class OrderFood
    {
        public int? Id { get; set; }
        public int RequestId { get; set; }
        public int FoodId { get; set; }
        public int Count { get; set; }
    }
}
