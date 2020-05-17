using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class DishBindingModel
    {
        public int? Id { get; set; }
        public string DishName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> DishFoods { get; set; }
    }
}
