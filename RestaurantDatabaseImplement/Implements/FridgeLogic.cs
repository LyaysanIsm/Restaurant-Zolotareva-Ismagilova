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
        public List<FridgeViewModel> GetList()
        {
            using (var context = new RestaurantDatabase())
            {
                return context.Fridges
                .ToList()
               .Select(rec => new FridgeViewModel
               {
                   Id = rec.Id,
                   FridgeName = rec.FridgeName,
                   FridgeFoods = context.FridgeFoods,
                   Capacity = rec.Capacity
               .Include(recFF => recFF.Food)
               .Where(recFF => recFF.FridgeId == rec.Id).
               Select(x => new FridgeFoodViewModel
               {
                   Id = x.Id,
                   FridgeId = x.FridgeId,
                   FoodId = x.FoodId,
                   FoodName = context.Foods.FirstOrDefault(y => y.Id == x.FoodId).FoodName,
                   Count = x.Count,
                   IsReserved = x.IsReserved
               })
               .ToList()
               })
            .ToList();
            }
        }
        public FridgeViewModel GetElement(int id)
        {
            using (var context = new RestaurantDatabase())
            {
                var elem = context.Fridges.FirstOrDefault(x => x.Id == id);
                if (elem == null)
                {
                    throw new Exception("Элемент не найден");
                }
                else
                {
                    return new FridgeViewModel
                    {
                        Id = id,
                        FridgeName = elem.FridgeName,
                        FridgeFoods = context.FridgeFoods,
                        Capacity = elem.Capacity
                .Include(recSF => recSF.Food)
                .Where(recSF => recSF.FridgeId == elem.Id)
                        .Select(x => new FridgeFoodViewModel
                        {
                            Id = x.Id,
                            FridgeId = x.FridgeId,
                            FoodId = x.FoodId,
                            FoodName = context.Foods.FirstOrDefault(y => y.Id == x.FoodId).FoodName,
                            Count = x.Count,
                            IsReserved = x.IsReserved
                        }).ToList()
                    };
                }
            }
        }
        public void AddElement(FridgeBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                var elem = context.Fridges.FirstOrDefault(x => x.FridgeName == model.FridgeName);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var fridge = new Fridge();
                context.Fridges.Add(fridge);
                fridge.FridgeName = model.FridgeName;
                context.SaveChanges();
            }
        }
        public void UpdElement(FridgeBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                var elem = context.Fridges.FirstOrDefault(x => x.FridgeName == model.FridgeName && x.Id != model.Id);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var elemToUpdate = context.Fridges.FirstOrDefault(x => x.Id == model.Id);
                if (elemToUpdate != null)
                {
                    elemToUpdate.FridgeName = model.FridgeName;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public void DelElement(int id)
        {
            using (var context = new RestaurantDatabase())
            {
                var elem = context.Fridges.FirstOrDefault(x => x.Id == id);
                if (elem != null)
                {
                    context.Fridges.Remove(elem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public void FillFridge(FridgeFoodBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                var item = context.FridgeFoods.FirstOrDefault(x => x.FoodId == model.FoodId
    && x.FridgeId == model.FridgeId);

                if (item != null)
                {
                    item.Count += model.Count;
                }
                else
                {
                    var elem = new FridgeFood();
                    context.FridgeFoods.Add(elem);
                    elem.FridgeId = model.FridgeId;
                    elem.FoodId = model.FoodId;
                    elem.Count = model.Count;
                    elem.IsReserved = model.IsReserved;
                }
                context.SaveChanges();
            }
        }
        public void RemoveFromFridge(OrderViewModel order)
        {
            using (var context = new RestaurantDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var DishFoods = context.DishFoods.Where(x => x.DishId == order.DishId).ToList();
                        var FridgeFoods = context.FridgeFoods.ToList();
                        foreach (var food in DishFoods)
                        {
                            var foodCount = food.Count * order.Count;
                            foreach (var sb in FridgeFoods)
                            {
                                if (sb.FoodId == food.FoodId && sb.Count >= foodCount)
                                {
                                    sb.Count -= foodCount;
                                    foodCount = 0;
                                    context.SaveChanges();
                                    break;
                                }
                                else if (sb.FoodId == food.FoodId && sb.Count < foodCount)
                                {
                                    foodCount -= sb.Count;
                                    sb.Count = 0;
                                    context.SaveChanges();
                                }
                            }
                            if (foodCount > 0)
                                throw new Exception("Недостаточно продуктов на складе");
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