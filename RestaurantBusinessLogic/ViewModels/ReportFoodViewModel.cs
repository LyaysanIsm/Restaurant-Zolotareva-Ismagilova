using RestaurantBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.ViewModels
{
    public class ReportFoodViewModel
    {
        public string SupplierFIO { get; set; }
        public string FoodName { get; set; }
        public int Count { get; set; }
        public string Status { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Price { get; set; }
    }
}
