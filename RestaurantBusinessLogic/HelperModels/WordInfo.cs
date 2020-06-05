using RestaurantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
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
        public DateTime DateComplete { get; set; }
        public Dictionary<int, (string, int, bool)> RequestFoods { get; set; }
    }
}