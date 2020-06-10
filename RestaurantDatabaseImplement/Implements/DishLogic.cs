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
    public class DishLogic : IDishLogic
    {
        public void CreateOrUpdate(DishBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Dish element = context.Dishes.FirstOrDefault(rec =>
                       rec.DishName == model.DishName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Dishes.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Dish();
                            context.Dishes.Add(element);
                        }
                        element.DishName = model.DishName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var DishFoods = context.DishFoods.Where(rec
                           => rec.DishId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.DishFoods.RemoveRange(DishFoods.Where(rec =>
                            !model.DishFoods.ContainsKey(rec.FoodId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateFood in DishFoods)
                            {
                                updateFood.Count =
                               model.DishFoods[updateFood.FoodId].Item2;

                                model.DishFoods.Remove(updateFood.FoodId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.DishFoods)
                        {
                            context.DishFoods.Add(new DishFood
                            {
                                DishId = element.Id,
                                FoodId = pc.Key,
                                Count = pc.Value.Item2
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
        public void Delete(DishBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по продуктам при удалении закуски
                        context.DishFoods.RemoveRange(context.DishFoods.Where(rec =>
                        rec.DishId == model.Id));
                        Dish element = context.Dishes.FirstOrDefault(rec => rec.Id
                        == model.Id);
                        if (element != null)
                        {
                            context.Dishes.Remove(element);
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
        public List<DishViewModel> Read(DishBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                return context.Dishes
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new DishViewModel
                {
                    Id = rec.Id,
                    DishName = rec.DishName,
                    Price = rec.Price,
                    DishFoods = context.DishFoods
                                        .Include(recPC => recPC.Food)
                                        .Where(recPC => recPC.DishId == rec.Id)
                                        .ToDictionary(recPC => recPC.FoodId, recPC => (
                                            recPC.Food?.FoodName, recPC.Count
                                         ))
                }).ToList();
            }
        }

        public void SaveJsonDish(string folderName)
        {
            string fileName = $"{folderName}\\Dish.json";
            using (var context = new RestaurantDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<Dish>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Dishes);
                }
            }
        }

        public void SaveJsonDishFood(string folderName)
        {
            string fileName = $"{folderName}\\DishFood.json";
            using (var context = new RestaurantDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<DishFood>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.DishFoods);
                }
            }
        }

        public void SaveXmlDish(string folderName)
        {
            string fileName = $"{folderName}\\Dish.xml";
            using (var context = new RestaurantDatabase())
            {
                XmlSerializer fomatter = new XmlSerializer(typeof(DbSet<Dish>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    fomatter.Serialize(fs, context.Dishes);
                }
            }
        }

        public void SaveXmlDishFood(string folderName)
        {
            string fileName = $"{folderName}\\DishFood.xml";
            using (var context = new RestaurantDatabase())
            {
                XmlSerializer fomatter = new XmlSerializer(typeof(DbSet<DishFood>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    fomatter.Serialize(fs, context.DishFoods);
                }
            }
        }
    }
}
