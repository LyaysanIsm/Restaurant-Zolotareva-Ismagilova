using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class FridgeFoodBindingModel
    {
        public int Id { get; set; }
        public int FridgeId { get; set; }
        public int FoodId { get; set; }
        public int Count { get; set; }
        public int IsReserved { get; set; }
    }
}