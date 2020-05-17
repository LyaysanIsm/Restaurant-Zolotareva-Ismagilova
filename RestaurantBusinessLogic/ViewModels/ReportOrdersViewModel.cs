using RestaurantBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime CreationDate { get; set; }
        public string DishName { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
        public Status Status { get; set; }
    }
}
