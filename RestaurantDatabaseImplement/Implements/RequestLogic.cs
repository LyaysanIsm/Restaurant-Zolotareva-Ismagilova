using Microsoft.EntityFrameworkCore;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Enums;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.ViewModels;
using RestaurantDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace RestaurantDatabaseImplement.Implements
{
    public class RequestLogic : IRequestLogic
    {
        public void CreateOrUpdate(RequestBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Request request;
                        if (model.Id.HasValue)
                        {
                            request = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
                            if (request == null)
                            {
                                throw new Exception("Заявка не найдена");
                            }
                            var requestFoods = context.RequestFoods
                                .Where(rec => rec.RequestId == model.Id.Value).ToList();
                            context.RequestFoods.RemoveRange(requestFoods.Where(rec =>
                                !model.Foods.ContainsKey(rec.FoodId)).ToList());
                            foreach (var updFood in requestFoods)
                            {
                                updFood.Count = model.Foods[updFood.FoodId].Item2;
                                updFood.Inres = model.Foods[updFood.FoodId].Item3;
                                model.Foods.Remove(updFood.FoodId);
                            }
                            request.CompletionDate = model.CompletionDate;
                            context.SaveChanges();
                        }
                        else
                        {
                            request = new Request();
                            context.Requests.Add(request);
                        }
                        request.SupplierId = model.SupplierId;
                        request.Sum = model.Sum;
                        request.CreationDate = model.CreationDate;
                        request.Status = model.Status;
                        context.SaveChanges();
                        foreach (var Food in model.Foods)
                        {
                            context.RequestFoods.Add(new RequestFood
                            {
                                RequestId = request.Id,
                                FoodId = Food.Key,
                                Count = Food.Value.Item2,
                                Inres = false
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(RequestBindingModel model)
        {
            if (model.Status != RequestStatus.Выполняется)
            {
                using (var context = new RestaurantDatabase())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.RequestFoods.RemoveRange(context
                                .RequestFoods.Where(rec => rec.RequestId == model.Id));
                            Request request = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
                            if (request != null)
                            {
                                context.Requests.Remove(request);
                                context.SaveChanges();
                            }
                            else
                            {
                                throw new Exception("Заявка не найдена");
                            }
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Заявку невозможно удалить. Заявка в процессе");
            }
        }

        public List<RequestViewModel> Read(RequestBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                return context.Requests
                    .Include(rec => rec.Supplier)
                    .Where(rec => model == null || rec.Id == model.Id || (rec.SupplierId == model.SupplierId) && (model.DateFrom == null && model.DateTo == null ||
                    rec.CreationDate >= model.DateFrom && rec.CreationDate <= model.DateTo && rec.Status == RequestStatus.Готова))
                    .ToList()
                    .Select(rec => new RequestViewModel
                    {
                        Id = rec.Id,
                        SupplierFIO = rec.Supplier.SupplierFIO,
                        SupplierId = rec.SupplierId,
                        CompletionDate = rec.CompletionDate,
                        CreationDate = rec.CreationDate,
                        Status = rec.Status,
                        Sum = rec.Sum,
                        Foods = context.RequestFoods
                            .Include(recRF => recRF.Food)
                            .Where(recRF => recRF.RequestId == rec.Id)
                            .ToDictionary(recRF => recRF.FoodId, recRF =>
                            (recRF.Food?.FoodName, recRF.Count, recRF.Inres))
                    })
                    .ToList();
            }
        }
        public void Reserve(ReserveFoodsBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                var requestFoods = context.RequestFoods.FirstOrDefault(rec =>
                rec.RequestId == model.RequestId && rec.FoodId == model.FoodId);
                if (requestFoods == null)
                {
                    throw new Exception("Продукта нет в заявке");
                }
                requestFoods.Inres = true;
                context.SaveChanges();
            }
        }

        public void SaveJsonRequest(string folderName)
        {
            string fileName = $"{folderName}\\Request.json";
            using (var context = new RestaurantDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<Request>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Requests);
                }
            }
        }

        public void SaveJsonRequestFood(string folderName)
        {
            string fileName = $"{folderName}\\RequestFood.json";
            using (var context = new RestaurantDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<RequestFood>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.RequestFoods);
                }
            }
        }

        public void SaveXmlRequest(string folderName)
        {
            string fileNameDop = $"{folderName}\\Request.xml";
            using (var context = new RestaurantDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Request>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Requests);
                }
            }
        }

        public void SaveXmlRequestFood(string folderName)
        {
            string fileNameDop = $"{folderName}\\RequestFood.xml";
            using (var context = new RestaurantDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<RequestFood>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.RequestFoods);
                }
            }
        }
    }
}