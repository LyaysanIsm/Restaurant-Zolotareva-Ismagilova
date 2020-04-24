using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class Product
    {
        public int? Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}