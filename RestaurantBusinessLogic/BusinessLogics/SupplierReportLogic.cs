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
using System.Text;

namespace RestaurantBusinessLogic.BusinessLogics
{
    public class SupplierReportLogic
    {
        private readonly IFoodLogic foodLogic;
        private readonly IRequestLogic requestLogic;
        private readonly IFridgeLogic fridgeLogic;

        public SupplierReportLogic(IFoodLogic foodLogic, IRequestLogic requestLogic, IFridgeLogic fridgeLogic)
        {
            this.foodLogic = foodLogic;
            this.requestLogic = requestLogic;
            this.fridgeLogic = fridgeLogic;
        }

        public List<FoodViewModel> GetReserveFoods(RequestViewModel request)
        {
            var foods = new List<FoodViewModel>();
            foreach (var food in request.Foods)
            {
                foods.Add(foodLogic.Read(new FoodBindingModel
                {
                    Id = food.Key
                }).FirstOrDefault());
            }
            return foods;
        }

        public void SaveNeedFoodToWordFile(string fileName, RequestViewModel request, string email)
        {
            string title = "Список требуемых продуктов по заявке" + "" + request.Id;
            SupplierSaveToWord.CreateDoc(new WordInfo
            {
                FileName = fileName,
                Title = title,
                Foods = GetReserveFoods(request)
            });
            SendMail(email, fileName, title);
        }

        public void SaveNeedFoodToExcelFile(string fileName, RequestViewModel request, string email)
        {
            string title = "Список требуемых продуктов по заявке" + "" + request.Id;
            SupplierSaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = fileName,
                Title = title,
                Foods = GetReserveFoods(request)
            });
            SendMail(email, fileName, title);
        }

        public void SendMail(string email, string fileName, string subject)
        {
            MailAddress from = new MailAddress("lyaysanlabs@gmail.com", "Столовая Рога и Копыта");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Attachments.Add(new Attachment(fileName));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("lyaysanlabs@gmail.com", "987-654lL");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}