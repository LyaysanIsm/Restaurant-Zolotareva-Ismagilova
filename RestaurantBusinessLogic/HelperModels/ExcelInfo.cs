using RestaurantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<IGrouping<DateTime, OrderViewModel>> Orders { get; set; }
        public List<FridgeViewModel> Fridges { get; set; }
        public List<FoodViewModel> Foods { get; set; }
    }
}