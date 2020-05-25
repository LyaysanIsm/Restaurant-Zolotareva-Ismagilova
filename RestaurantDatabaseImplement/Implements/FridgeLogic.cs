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
                    Foods = context.FridgeFoods
                            .Include(recCC => recCC.Food)
                            .Where(recCC => recCC.FridgeId == rec.Id)
                            .ToDictionary(recCC => recCC.FoodId, recCC =>
                            (recCC.Food?.FoodName, recCC.Count, recCC.Reserved))
                })
                    .ToList();
            }
        }

        public void CreateOrUpdate(FridgeBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                Fridge element = context.Fridges.FirstOrDefault(rec => rec.FridgeName == model.FridgeName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("There is already a fridge with this name");
                }
                if (model.Id.HasValue)
                {
                    element = context.Fridges.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Fridge not found");
                    }
                }
                else
                {
                    element = new Fridge();
                    context.Fridges.Add(element);
                }
                element.FridgeName = model.FridgeName;
                element.Capacity = model.Capacity;
                element.Type = model.Type;
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
                            throw new Exception("Fridge not found");
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

        public void AddFood(ReserveFoodsBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                var FridgeFood = context.FridgeFoods
                    .FirstOrDefault(sm => sm.FoodId == model.FoodId && sm.FridgeId == model.FridgeId);
                if (FridgeFood != null)
                    FridgeFood.Count += model.Count;
                else
                    context.FridgeFoods.Add(new FridgeFood()
                    {
                        FoodId = model.FoodId,
                        FridgeId = model.FridgeId,
                        Count = model.Count
                    });
                context.SaveChanges();
            }
        }

        public void RemoveFoods(OrderViewModel order)
        {
            using (var context = new RestaurantDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var dishfoods = context.DishFoods.Where(dm => dm.DishId == order.DishId).ToList();
                        var FridgeFoods = context.DishFoods.ToList();
                        foreach (var food in dishfoods)
                        {
                            var foodCount = food.Count * order.Count;
                            foreach (var df in dishfoods)
                            {
                                if (df.FoodId == food.FoodId && df.Count >= foodCount)
                                {
                                    df.Count -= foodCount;
                                    foodCount = 0;
                                    context.SaveChanges();
                                    break;
                                }
                                else if (df.FoodId == food.FoodId && df.Count < foodCount)
                                {
                                    foodCount -= df.Count;
                                    df.Count = 0;
                                    context.SaveChanges();
                                }
                            }
                            if (foodCount > 0)
                                throw new Exception("Not enough foods in the fridges!");
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
    }
}