using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.ViewModels;
using RestaurantDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml.Serialization;

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
                element.Count = model.Count;
                element.Sum = model.Sum;
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
                Count = rec.Count,
                Sum = rec.Dish.Price,
                Status = rec.Status,
                CreationDate = rec.CreationDate,
                CompletionDate = rec.CompletionDate
            })
            .ToList();
            }
        }

        public void SaveJson(string folderName)
        {
            string fileName = $"{folderName}\\order.json";
            using (var context = new RestaurantDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Orders);
                }
            }
        }

        public void SaveXml(string folderName)
        {
            string fileName = $"{folderName}\\order.xml";
            using (var context = new RestaurantDatabase())
            {
                XmlSerializer fomatter = new XmlSerializer(typeof(DbSet<Order>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    fomatter.Serialize(fs, context.Orders);
                }
            }
        }
    }
}
