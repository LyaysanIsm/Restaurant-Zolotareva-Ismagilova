using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RestaurantBusinessLogic.ViewModels
{
    public class FridgeAvailableViewModel
    {
        [DisplayName("Холодильник")]
        public string FridgeName { get; set; }
        public int FridgeId { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}