using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.BusinessLogic;
using RestaurantBusinessLogic.Enums;
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
        private readonly IFoodLogic foodLogic;
        private readonly IRequestLogic requestLogic;

        public ReportLogic(IDishLogic dishLogic, IOrderLogic orderLogic, 
            IFoodLogic foodLogic, IRequestLogic requestLogic)
        {
            this.dishLogic = dishLogic;
            this.orderLogic = orderLogic;
            this.foodLogic = foodLogic;
            this.requestLogic = requestLogic;
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

        public List<ReportFoodViewModel> GetFoods(DateTime from, DateTime to)
        {
            var foods = foodLogic.Read(null);
            var requests = requestLogic.Read(null);
            var list = new List<ReportFoodViewModel>();
            foreach (var request in requests)
            {
                foreach (var requestFood in request.Foods)
                {
                    foreach (var food in foods) 
                    {
                        if (food.FoodName == requestFood.Value.Item1)
                        {
                            var record = new ReportFoodViewModel
                            {
                                FoodName = requestFood.Value.Item1,
                                Count = requestFood.Value.Item2,
                                Status = StatusFood(request.Status),
                                CompletionDate = DateTime.Now,
                                Price = food.Price
                            };
                            list.Add(record);
                        }
                    }
                }
            }
            return list;
        }

        public string StatusFood(RequestStatus requestStatus)
        {
            if (requestStatus == RequestStatus.Создана)
                return "Ждут отправки";
            if (requestStatus == RequestStatus.Выполняется)
                return "В пути";
            if (requestStatus == RequestStatus.Готова)
                return "Поставлено";
            if (requestStatus == RequestStatus.Обработана)
                return "Использовано";
            return "";
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
            SendMail("kristina.zolotareva.14@gmail.com", model.FileName, "Список блюд с продуктами");
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
            SendMail("kristina.zolotareva.14@gmail.com", model.FileName, "Список блюд с продуктами");
        }

        public void SaveFoodsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Движение продуктов",
                Foods = GetFoods(model.DateFrom, model.DateTo)
            });
        }

        public void SendMail(string email, string fileName, string subject)
        {
            MailAddress from = new MailAddress("labwork15kafis@gmail.com", "Столовая Рога и Копыта");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Attachments.Add(new Attachment(fileName));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("labwork15kafis@gmail.com", "passlab15");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        public void SendMailReport(string email, string fileName, string subject, string type)
        {
            MailAddress from = new MailAddress("labwork15kafis@gmail.com", "Столовая Рога и Копыта");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Attachments.Add(new Attachment(fileName + "\\order." + type));
            m.Attachments.Add(new Attachment(fileName + "\\request." + type));
            m.Attachments.Add(new Attachment(fileName + "\\dish." + type));
            m.Attachments.Add(new Attachment(fileName + "\\food." + type));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("labwork15kafis@gmail.com", "passlab15");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}