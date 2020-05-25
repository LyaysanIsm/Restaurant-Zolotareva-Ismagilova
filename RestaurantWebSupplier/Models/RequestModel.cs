using RestaurantBusinessLogic.Enums;
using RestaurantDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebSupplier.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public RequestStatus Status { get; set; }
        public List<RequestFoodModel> RequestFoods { get; set; }
    }
}