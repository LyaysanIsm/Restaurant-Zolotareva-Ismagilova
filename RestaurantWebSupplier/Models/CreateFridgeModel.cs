using RestaurantDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebSupplier.Models
{
    public class CreateFridgeModel
    {
        public int Id { get; set; }
        public string FridgeName { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public virtual List<FridgeFood> FridgeFoods { get; set; }
        public int SupplierId { get; set; }
    }
}