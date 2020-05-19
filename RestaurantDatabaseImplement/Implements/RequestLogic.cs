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
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                context.SaveChanges();
            }
        }
        public void Delete(RequestBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                Request element = context.Requests.FirstOrDefault(rec => rec.Id ==
model.Id);
                if (element != null)
                {
                    context.Requests.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<RequestViewModel> Read(RequestBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                return context.Requests
                .Where(rec => model == null || (rec.Id == model.Id && model.Id.HasValue)
                || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo) ||
                (model.SupplierId.HasValue && rec.SupplierId == model.SupplierId))
                .Include(rec => rec.Supplier)
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    SupplierId = rec.SupplierId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    SupplierFIO = rec.Supplier.SupplierFIO
                })
            .ToList();
            }
        }
    }
}