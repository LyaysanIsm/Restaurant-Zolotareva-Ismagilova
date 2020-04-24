using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class FoodDish
    {
        public int? Id { get; set; }
        public int FoodId { get; set; }
        public int DishId { get; set; }
        public int Count { get; set; }
    }
}
