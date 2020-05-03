using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RestaurantBusinessLogic.ViewModels
{
    public class FridgeFoodViewModel
    {
        public int FridgeId { get; set; }
        public int FoodId { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Резервация")]
        public int IsReserved { get; set; }
    }
}