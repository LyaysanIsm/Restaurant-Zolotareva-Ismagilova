using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class CreateRequestBindingModel
    {
        public int? SupplierId { get; set; }
        public Dictionary<int, (string, int)> Foods { get; set; }
    }
}