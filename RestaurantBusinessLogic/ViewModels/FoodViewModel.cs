using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RestaurantBusinessLogic.ViewModels
{
    public class FoodViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название продукта")]
        public string FoodName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
    }
}