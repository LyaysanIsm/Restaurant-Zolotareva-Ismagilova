using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.ViewModels;
using RestaurantDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantDatabaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order();
                    context.Orders.Add(element);
                }
                element.DishId = model.DishId == 0 ? element.DishId : model.DishId;
                element.Amount = model.Amount;
                element.Status = model.Status;
                element.CreationDate = model.CreationDate;
                element.CompletionDate = model.CompletionDate;
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                return context.Orders
            .Include(rec => rec.Dish)
            .Where(
                    rec => model == null
                    || (rec.Id == model.Id && model.Id.HasValue)
                    || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.CreationDate >= model.DateFrom && rec.CreationDate <= model.DateTo))
            .Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                DishName = rec.Dish.DishName,
                Amount = rec.Amount,
                Status = rec.Status,
                CreationDate = rec.CreationDate,
                CompletionDate = rec.CompletionDate
            })
            .ToList();
            }
        }
    }
}
