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
using System.Text;

namespace RestaurantBusinessLogic.BusinessLogics
{
    public class SupplierReportLogic
    {
        private readonly IRequestLogic requestLogic;
        private readonly IFoodLogic foodLogic;
        public SupplierReportLogic(IRequestLogic requestLogic, IFoodLogic foodLogic)
        {
            this.requestLogic = requestLogic;
            this.foodLogic = foodLogic;
        }

        public Dictionary<int, (string, int, bool)> GetRequestFoods(int requestId)
        {
            var requestFoods = requestLogic.Read(new RequestBindingModel
            {
                Id = requestId
            })?[0].Foods;
            return requestFoods;
        }

        public List<ReportFoodViewModel> GetFoods(RequestBindingModel model)
        {
            var foods = foodLogic.Read(null);
            var requests = requestLogic.Read(model);
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
                                RequestId = request.Id,
                                SupplierFIO = request.SupplierFIO,
                                FoodName = requestFood.Value.Item1,
                                Count = requestFood.Value.Item2,
                                Status = StatusFood(request.Status),
                                CompletionDate = request.CompletionDate,
                                Price = food.Price,
                                Sum = request.Sum
                            };
                            list.Add(record);
                        }
                    }
                }
            }
            return list;
        }

        public void SaveNeedFoodToWordFile(WordInfo wordInfo, string email)
        {
            string title = "Список требуемых продуктов по заявке №" + wordInfo.RequestId;
            wordInfo.Title = title;
            wordInfo.FileName = wordInfo.FileName;
            wordInfo.RequestFoods = GetRequestFoods(wordInfo.RequestId);
            SupplierSaveToWord.CreateDoc(wordInfo);
            SendMail(email, wordInfo.FileName, title);
        }

        public void SaveNeedFoodToExcelFile(ExcelInfo excelInfo, string email)
        {
            string title = "Список требуемых продуктов по заявке №" + excelInfo.RequestId;
            excelInfo.Title = title;
            excelInfo.FileName = excelInfo.FileName;
            excelInfo.RequestFoods = GetRequestFoods(excelInfo.RequestId);
            SupplierSaveToExcel.CreateDoc(excelInfo);
            SendMail(email, excelInfo.FileName, title);
        }

        public void SaveFoodsToPdfFile(string fileName, RequestBindingModel model, string email)
        {
            string title = "Список продуктов в период с " + model.DateFrom.ToString() + " по " + model.DateTo.ToString();
            SupplierSaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = fileName,
                Title = title,
                Foods = GetFoods(model)
            });
            SendMail(email, fileName, title);
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

        public void SendMailBackup(string email, string fileName, string subject, string type)
        {
            MailAddress from = new MailAddress("lyaysanlabs@gmail.com", "Столовая Рога и Копыта");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Attachments.Add(new Attachment(fileName + "\\Request." + type));
            m.Attachments.Add(new Attachment(fileName + "\\RequestFood." + type));
            m.Attachments.Add(new Attachment(fileName + "\\Fridge." + type));
            m.Attachments.Add(new Attachment(fileName + "\\FridgeFood." + type));
            m.Attachments.Add(new Attachment(fileName + "\\Supplier." + type));
            m.Attachments.Add(new Attachment(fileName + "\\Food." + type));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("lyaysanlabs@gmail.com", "987-654lL");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}