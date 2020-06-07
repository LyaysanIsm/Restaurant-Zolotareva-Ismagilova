using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.BusinessLogic;
using RestaurantBusinessLogic.HelperModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

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
                foreach (var ff in fridge.Foods)
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

        public List<ReportOrdersViewModel> GetOrder(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                CreationDate = x.CreationDate,
                DishName = x.DishName,
                Count = x.Count,
                Amount = x.Sum,
                Status = x.Status
            })
            .ToList();
        }

        public List<ReportOrdersViewModel> GetReportOrder(ReportBindingModel model)
        {
            var dishes = orderLogic.Read(null);
            var list = new List<ReportOrdersViewModel>();
            foreach (var dish in dishes)
            {
                var record = new ReportOrdersViewModel
                {
                    DishName = dish.DishName,
                    Amount = dish.Sum,
                    Count = dish.Count,
                    CreationDate = dish.CreationDate,
                    Status = dish.Status
                };
                list.Add(record);
            }
            return list;
        }

        public void SaveOrdersToWordFile(ReportBindingModel model)
        {
            try
            {
                SaveToWord.CreateDoc(new WordInfo
                {
                    FileName = model.FileName,
                    Title = "Список приготовленных блюд",
                    Orders = GetReportOrder(model),
                    DishFoods = GetDishFoods()
                });
            } catch(Exception)
            {
                throw;
            }
        }

        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список приготовленных блюд",
                Orders = GetReportOrder(model),
                DishFoods = GetDishFoods()
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

        public void SendMail(string email, string fileName, string subject)
        {
            MailAddress from = new MailAddress("kristina.zolotareva.14@gmail.com", "Столовая Рога и Копыта");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Attachments.Add(new Attachment(fileName));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("kristina.zolotareva.14@gmail.com", "1");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}