using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class SupplierBindingModel
    {
        public int? Id { get; set; }
        public string SupplierFIO { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}