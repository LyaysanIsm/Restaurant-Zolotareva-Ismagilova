using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.ViewModels;
using RestaurantDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantDatabaseImplement.Implements
{
    public class FoodLogic : IFoodLogic
    {
        public void CreateOrUpdate(FoodBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                Food element = context.Foods.FirstOrDefault(rec =>
               rec.FoodName == model.FoodName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть продукт с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Foods.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Food();
                    context.Foods.Add(element);
                }
                element.FoodName = model.FoodName;
                element.Price = model.Price.Value;
                context.SaveChanges();
            }
        }
        public void Delete(FoodBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                Food element = context.Foods.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Foods.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<FoodViewModel> Read(FoodBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                return context.Foods
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new FoodViewModel
                {
                    Id = rec.Id,
                    FoodName = rec.FoodName,
                    Price = rec.Price
                })
                .ToList();
            }
        }
    }
}
