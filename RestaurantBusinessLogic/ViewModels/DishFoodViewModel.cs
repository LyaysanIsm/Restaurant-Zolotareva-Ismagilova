using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RestaurantBusinessLogic.ViewModels
{
    public class DishFoodViewModel
    {
        public int? Id { get; set; }
        public int FoodId { get; set; }
        public int DishId { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
