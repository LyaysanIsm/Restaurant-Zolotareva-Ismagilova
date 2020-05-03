using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class SupplierBindingModel
    {
        public int? Id { get; set; }
        public string SupplierName { get; set; }
        public int Password { get; set; }
        public int FridgeId { get; set; }
    }
}