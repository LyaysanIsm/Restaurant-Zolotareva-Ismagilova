using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RestaurantBusinessLogic.ViewModels
{
    public class DishViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название блюда")]
        public string DishName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> DishFoods { get; set; }
    }
}
