using Microsoft.EntityFrameworkCore;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.ViewModels;
using RestaurantDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace RestaurantDatabaseImplement.Implements
{
    public class FridgeLogic : IFridgeLogic
    {
        public List<FridgeViewModel> Read(FridgeBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                return context.Fridges
                .Where(rec => model == null || rec.Id == model.Id
                    || rec.SupplierId == model.SupplierId)
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
                            (recCC.Food?.FoodName, recCC.Free, recCC.Reserved))
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
                    throw new Exception("Уже существует холодильник с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Fridges.FirstOrDefault(rec => rec.Id == model.Id);
                    int free = context.FridgeFoods.Where(rec =>
                    rec.FridgeId == model.Id).Sum(rec => rec.Free);
                    int res = context.FridgeFoods.Where(rec =>
                    rec.FridgeId == model.Id).Sum(rec => rec.Reserved);
                    if ((free + res) > model.Capacity)
                    {
                        throw new Exception("Вместимость не может быть меньше количества продуктов в холодильнике");
                    }
                    if (element == null)
                    {
                        throw new Exception("Холодильник не найден");
                    }
                }
                else
                {
                    element = new Fridge();
                    context.Fridges.Add(element);
                }
                element.SupplierId = model.SupplierId;
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
                            throw new Exception("Холодильник не найден");
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

        public List<FridgeAvailableViewModel> GetFridgeAvailable(RequestFoodBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                return context.FridgeFoods
                .Include(rec => rec.Fridge)
                .Where(rec => rec.FoodId == model.FoodId
                && rec.Free >= model.Count)
                .Select(rec => new FridgeAvailableViewModel
                {
                    FridgeId = rec.FridgeId,
                    FridgeName = rec.Fridge.FridgeName,
                    Count = rec.Free
                })
                .ToList();
            }
        }

        public void AddFood(RequestFoodBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                var fridgeFoods = context.FridgeFoods.FirstOrDefault(rec =>
                 rec.FridgeId == model.FridgeId && rec.FoodId == model.FoodId);
                var fridge = context.Fridges.FirstOrDefault(rec => rec.Id == model.FridgeId);

                int free = context.FridgeFoods.Where(rec =>
                rec.FridgeId == model.FridgeId).Sum(rec => rec.Free);
                int res = context.FridgeFoods.Where(rec =>
                rec.FridgeId == model.FridgeId).Sum(rec => rec.Reserved);
                if ((free + res + model.Count) > fridge.Capacity)
                {
                    throw new Exception("Недостаточно места в холодильнике");
                }
                if (fridgeFoods == null)
                {
                    context.FridgeFoods.Add(new FridgeFood
                    {
                        FridgeId = model.FridgeId,
                        FoodId = model.FoodId,
                        Free = model.Count,
                        Reserved = 0
                    });
                }
                else
                {
                    fridgeFoods.Free += model.Count;
                }
                context.SaveChanges();
            }
        }

        public void ReserveFoods(RequestFoodBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                var fridgeFoods = context.FridgeFoods.FirstOrDefault(rec =>
                rec.FridgeId == model.FridgeId && rec.FoodId == model.FoodId);
                if (fridgeFoods != null)
                {
                    if (fridgeFoods.Free >= model.Count)
                    {
                        fridgeFoods.Free -= model.Count;
                        fridgeFoods.Reserved += model.Count;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Недостаточно продуктов для резервирования");
                    }
                }
                else
                {
                    throw new Exception("В холодильнике не существует таких продуктов");
                }
            }
        }

        public void SaveJsonFridge(string folderName)
        {
            string fileName = $"{folderName}\\Fridge.json";
            using (var context = new RestaurantDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<Fridge>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Fridges);
                }
            }
        }

        public void SaveJsonFridgeFood(string folderName)
        {
            string fileName = $"{folderName}\\FridgeFood.json";
            using (var context = new RestaurantDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<FridgeFood>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.FridgeFoods);
                }
            }
        }

        public void SaveXmlFridge(string folderName)
        {
            string fileNameDop = $"{folderName}\\Fridge.xml";
            using (var context = new RestaurantDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Fridge>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Fridges);
                }
            }
        }

        public void SaveXmlFridgeFood(string folderName)
        {
            string fileNameDop = $"{folderName}\\FridgeFood.xml";
            using (var context = new RestaurantDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<FridgeFood>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.FridgeFoods);
                }
            }
        }
    }
}