using RestaurantBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class RequestBindingModel
    {
        public int? Id { get; set; }
        public int? SupplierId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public Status Status { get; set; }
    }
}