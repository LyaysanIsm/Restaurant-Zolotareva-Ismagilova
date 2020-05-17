using RestaurantBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RestaurantBusinessLogic.ViewModels
{
    public class FridgeViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название холодильника")]
        public string FridgeName { get; set; }
        [DisplayName("Вместимость")]
        public int Capacity { get; set; }
        public List<FridgeFoodBindingModel> FridgeFoods { get; set; }
    }
}