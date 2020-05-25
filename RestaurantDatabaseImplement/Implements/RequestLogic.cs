using Microsoft.EntityFrameworkCore;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Enums;
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
                        Request request;
                        if (model.Id.HasValue)
                        {
                            request = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
                            if (request == null)
                            {
                                throw new Exception("Request not found");
                            }
                            else if (model.Status == RequestStatus.Created)
                            {
                                var requestFoods = context.RequestFoods
                                    .Where(rec => rec.RequestId == model.Id.Value).ToList();
                                context.RequestFoods.RemoveRange(requestFoods.Where(rec =>
                                    !model.Foods.ContainsKey(rec.FoodId)).ToList());
                                foreach (var updFood in requestFoods)
                                {
                                    updFood.Count = model.Foods[updFood.FoodId].Item2;
                                    model.Foods.Remove(updFood.FoodId);
                                }
                                context.SaveChanges();
                            }
                            else
                            {
                                throw new Exception("It isn't possible to change request. " +
                                    "Request is processed or executed");
                            }
                        }
                        else
                        {
                            request = new Request();
                            context.Requests.Add(request);
                        }
                        request.SupplierId = model.SupplierId;
                        request.Status = model.Status;
                        context.SaveChanges();
                        foreach (var Food in model.Foods)
                        {
                            context.RequestFoods.Add(new RequestFood
                            {
                                RequestId = request.Id,
                                FoodId = Food.Key,
                                Count = Food.Value.Item2
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
            if (model.Status != RequestStatus.Processed)
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
                                throw new Exception("Request not found");
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
                throw new Exception("It isn't possible to delete request. Request is processed");
            }
        }

        public List<RequestViewModel> Read(RequestBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                return context.Requests
                    .Include(rec => rec.Supplier)
                    .Where(rec => model == null || rec.Id == model.Id)
                    .ToList()
                    .Select(rec => new RequestViewModel
                    {
                        Id = rec.Id,
                        SupplierFIO = rec.Supplier.SupplierFIO,
                        Status = rec.Status,
                        Foods = context.RequestFoods
                            .Include(recRC => recRC.Food)
                            .Where(recRC => recRC.RequestId == rec.Id)
                            .ToDictionary(recRC => recRC.FoodId, recPC =>
                            (recPC.Food?.FoodName, recPC.Count))
                    })
                    .ToList();
            }
        }
    }
}