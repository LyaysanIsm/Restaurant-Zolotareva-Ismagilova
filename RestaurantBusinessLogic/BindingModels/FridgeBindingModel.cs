using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class FridgeBindingModel
    {
        public int? Id { get; set; }
        public int SupplierId { get; set; }
        public string FridgeName { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
    }
}