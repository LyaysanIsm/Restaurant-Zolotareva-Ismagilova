using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class Dish
    {
        public int? Id { get; set; }
        public string DishName { get; set; }
        public decimal Price { get; set; }
    }
}
