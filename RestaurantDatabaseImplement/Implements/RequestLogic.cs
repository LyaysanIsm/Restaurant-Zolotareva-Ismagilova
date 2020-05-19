using Microsoft.EntityFrameworkCore;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.ViewModels;
using RestaurantDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                        Request element;
                        if (model.Id.HasValue)
                        {
                            element = context.Requests.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Request();
                            context.Requests.Add(element);
                        }
                        element.SupplierId = model.SupplierId == null ? element.SupplierId : (int)model.SupplierId;
                       // element.Count = model.Count;
                        element.Sum = model.Sum;
                        element.Status = model.Status;
                        element.DateCreate = model.DateCreate;
                        element.DateImplement = model.DateImplement;
                        var groupFoods = model.RequestFoods
                        .GroupBy(rec => rec.FoodId)
                        .Select(rec => new
                        {
                            FoodId = rec.Key,
                            Count = rec.Sum(r => r.Count)
                        });
                        foreach (var groupFood in groupFoods)
                        {
                            context.RequestFoods.Add(new RequestFood
                            {
                                RequestId = element.Id,
                                FoodId = groupFood.FoodId,
                                Count = groupFood.Count
                            });
                            context.SaveChanges();
                            transaction.Commit();
                        }
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
            using (var context = new RestaurantDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.RequestFoods.RemoveRange(context.RequestFoods.Where(rec =>
                        rec.RequestId == model.Id));
                        Request element = context.Requests.FirstOrDefault(rec => rec.Id
                        == model.Id);
                        if (element != null)
                        {
                            context.Requests.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
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
        public List<RequestViewModel> Read(RequestBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                return context.Requests.Where(rec => model == null
                    || rec.Id == model.Id && model.Id.HasValue)
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    SupplierId = rec.SupplierId,                   
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    SupplierFIO = rec.Supplier.SupplierFIO,                    
                    RequestFoods = context.RequestFoods
                 .Where(recCI => recCI.RequestId == rec.Id)
                 .Select(recCI => new RequestFoodViewModel
                 {
                     Id = recCI.Id,
                     RequestId = recCI.RequestId,
                     FoodId = recCI.FoodId,
                     Count = recCI.Count
                 })
                    .ToList()
                })
                .ToList();
            }
        }
    }
}