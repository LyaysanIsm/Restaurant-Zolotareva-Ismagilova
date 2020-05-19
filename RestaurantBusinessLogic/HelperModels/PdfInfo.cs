using RestaurantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace RestaurantBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportDishFoodViewModel> DishFoods { get; set; }
        public List<ReportFridgeFoodViewModel> FridgeFoods { get; set; }
    }
}