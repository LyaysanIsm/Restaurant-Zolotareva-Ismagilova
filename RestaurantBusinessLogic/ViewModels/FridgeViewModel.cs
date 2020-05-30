using RestaurantBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RestaurantBusinessLogic.ViewModels
{
    public class FridgeViewModel
    {
        [DisplayName("Номер холодильника")]
        public int Id { get; set; }
        [DisplayName("Название холодильника")]
        public string FridgeName { get; set; }
        [DisplayName("Вместимость")]
        public int Capacity { get; set; }
        [DisplayName("Тип холодильника")]
        public string Type { get; set; }
        public Dictionary<int, (string, int, int)> Foods { get; set; }
    }
}