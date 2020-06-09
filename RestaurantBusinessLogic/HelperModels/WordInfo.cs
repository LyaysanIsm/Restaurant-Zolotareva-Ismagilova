using RestaurantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantBusinessLogic.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<DishViewModel> Dishes { get; set; }
        public List<FridgeViewModel> Fridges { get; set; }
        public int RequestId { get; set; }
        public string SupplierFIO { get; set; }
        public Dictionary<int, (string, int, bool)> RequestFoods { get; set; }
        public List<ReportDishFoodViewModel> DishFoods { get; set; }
        public List<ReportOrdersViewModel> Orders { get; set; }
    }
}