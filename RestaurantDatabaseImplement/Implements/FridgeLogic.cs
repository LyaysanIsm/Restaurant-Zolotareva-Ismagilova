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
    public class FridgeLogic : IFridgeLogic
    {
        public void CreateOrUpdate(FridgeBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                Fridge element = context.Fridges.FirstOrDefault(rec => rec.FridgeName == model.FridgeName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть холодильник с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Fridges.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Fridge();
                    context.Fridges.Add(element);
                }
                element.FridgeName = model.FridgeName;
                context.SaveChanges();
            }
        }

        public void Delete(FridgeBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.FridgeFoods.RemoveRange(context.FridgeFoods.Where(rec => rec.FridgeId == model.Id));
                        Fridge element = context.Fridges.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Fridges.Remove(element);
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

        public void AddFood(FridgeFoodBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                FridgeFood element = context.FridgeFoods.FirstOrDefault(rec => rec.FridgeId == model.FridgeId && rec.FoodId == model.FoodId);
                if (element != null)
                {
                    element.Count += model.Count;
                }
                else
                {
                    element = new FridgeFood();

                    context.FridgeFoods.Add(element);
                }
                element.FridgeId = model.FridgeId;
                element.FoodId = model.FoodId;
                element.Count = model.Count;
                element.IsReserved = model.IsReserved;
                context.SaveChanges();
            }
        }

        public List<FridgeViewModel> Read(FridgeBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                return context.Fridges
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new FridgeViewModel
                {
                    Id = rec.Id,
                    FridgeName = rec.FridgeName,
                    Capacity = rec.Capacity,
                    Type = rec.Type,
                    FridgeFoods = context.FridgeFoods
                    .Include(recFF => recFF.Food)
                    .Where(recFF => recFF.FridgeId == rec.Id)
                    .ToDictionary(recFF => recFF.FoodId, recFF => (
                    recFF.Food?.FoodName, recFF.Count))
                })
                .ToList();
            }
        }

        public void RemoveFromFridge(OrderViewModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var dishFoods = context.DishFoods.Where(rec => rec.DishId == model.DishId).ToList();
                        foreach (var pc in dishFoods)
                        {
                            var FridgeFood = context.FridgeFoods.Where(rec => rec.FoodId == pc.FoodId);
                            int neededCount = pc.Count * model.Count;
                            foreach (var FF in FridgeFood)
                            {
                                if (FF.Count >= neededCount)
                                {
                                    FF.Count -= neededCount;
                                    neededCount = 0;
                                    break;
                                }
                                else
                                {
                                    neededCount -= FF.Count;
                                    FF.Count = 0;
                                }
                            }
                            if (neededCount > 0)
                            {
                                throw new Exception("В холодильниках недостаточно продуктов");
                            }
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
    }
}