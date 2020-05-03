using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RestaurantBusinessLogic.ViewModels
{
    public class RequestFoodViewModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int FoodId { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}