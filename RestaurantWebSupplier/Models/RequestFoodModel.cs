using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebSupplier.Models
{
    public class RequestFoodModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int FoodId { get; set; }
        public int Count { get; set; }
    }
}