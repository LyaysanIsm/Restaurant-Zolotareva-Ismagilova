using RestaurantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace RestaurantBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportFoodViewModel> Foods { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
    }
}