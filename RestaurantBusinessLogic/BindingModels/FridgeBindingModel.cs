using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class FridgeBindingModel
    {
        public int Id { get; set; }
        public string FridgeName { get; set; }
        public int Capacity { get; set; }
        public List<FridgeFoodBindingModel> FridgeFoods { get; set; }
    }
}