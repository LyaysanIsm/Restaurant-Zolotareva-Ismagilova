using RestaurantBusinessLogic.BusinessLogic;
using RestaurantBusinessLogic.HelperModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
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
        public List<ReportFridgeFoodViewModel> GetFoods()
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

        public void SaveNeedFoodToWordFile(string fileName, RequestViewModel request, string email)
        {
            string title = "Список требуемых продуктов";
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = fileName,
                Title = title,
                //Foods = GetFoods()
            });
            SendMail(email, fileName, title);
        }
        public void SaveTravelToursToExcelFile(string fileName, RequestViewModel request, string email)
        {
            string title = "Список требуемых продуктов";
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = fileName,
                Title = title,
                //Foods = GetFoods()
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
            smtp.Credentials = new NetworkCredential("lyaysanlabs@gmail.com", "");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}