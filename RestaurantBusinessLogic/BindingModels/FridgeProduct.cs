using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class FridgeProduct
    {
        public int FridgeId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int isReserved { get; set; }
    }
}