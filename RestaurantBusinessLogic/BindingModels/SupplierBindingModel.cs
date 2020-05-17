using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class SupplierBindingModel
    {
        public int? Id { get; set; }
        public int FridgeId { get; set; }
        public string SupplierFIO { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
    }
}