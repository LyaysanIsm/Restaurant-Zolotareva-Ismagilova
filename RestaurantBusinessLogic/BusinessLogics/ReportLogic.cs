using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.BusinessLogic;
using RestaurantBusinessLogic.HelperModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IDishLogic dishLogic;
        private readonly IOrderLogic orderLogic;
        private readonly IFridgeLogic fridgeLogic;

        public ReportLogic(IDishLogic dishLogic, IOrderLogic orderLogic, IFridgeLogic fridgeLogic)
        {
            this.dishLogic = dishLogic;
            this.orderLogic = orderLogic;
            this.fridgeLogic = fridgeLogic;
        }

        public List<ReportDishFoodViewModel> GetDishFoods()
        {
            var dishes = dishLogic.Read(null);
            var list = new List<ReportDishFoodViewModel>();
            foreach (var dish in dishes)
            {
                foreach (var pc in dish.DishFoods)
                {
                    var record = new ReportDishFoodViewModel
                    {
                        DishName = dish.DishName,
                        FoodName = pc.Value.Item1,
                        Count = pc.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }

        public List<ReportFridgeFoodViewModel> GetFridgeFoods()
        {
            var fridges = fridgeLogic.Read(null);
            var list = new List<ReportFridgeFoodViewModel>();
            foreach (var fridge in fridges)
            {
                foreach (var ff in fridge.FridgeFoods)
                {
                    var record = new ReportFridgeFoodViewModel
                    {
                        FridgeName = fridge.FridgeName,
                        FoodName = ff.Value.Item1,
                        Count = ff.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }

        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
            .Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .GroupBy(rec => rec.CreationDate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();
            return list;
        }

        public void SaveDishsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список продуктов",
                Dishes = dishLogic.Read(null),
                Fridges = null
            });
        }

        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model),
                Fridges = null
            });
        }

        public void SaveDishFoodsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список блюд с продуктами",
                DishFoods = GetDishFoods(),
                FridgeFoods = null
            });
        }

        public void SaveFridgesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список холодильников",
                Dishes = null,
                Fridges = fridgeLogic.Read(null)
            });
        }

        public void SaveFridgeFoodsToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список продуктов в холодильниках",
                Orders = null,
                Fridges = fridgeLogic.Read(null)
            });
        }

        public void SaveFoodsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список продуктов",
                DishFoods = null,
                FridgeFoods = GetFridgeFoods()
            });
        }
    }
}