using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class FridgeFood
    {
        public int FridgeId { get; set; }
        public int FoodId { get; set; }
        public int Count { get; set; }
        public int isReserved { get; set; }
    }
}