using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.ViewModels;
using RestaurantDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDatabaseImplement.Implements
{
    public class SupplierLogic : ISupplierLogic
    {
        public void CreateOrUpdate(SupplierBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                Supplier element = context.Suppliers.FirstOrDefault(rec => rec.Email == model.Email && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть поставщик с таким логином");
                }
                if (model.Id.HasValue)
                {
                    element = context.Suppliers.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Supplier();
                    context.Suppliers.Add(element);
                }
                element.Email = model.Email;
                element.SupplierFIO = model.SupplierFIO;
                element.Password = model.Password;
                context.SaveChanges();
            }
        }

        public void Delete(SupplierBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                Supplier element = context.Suppliers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Suppliers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<SupplierViewModel> Read(SupplierBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                return context.Suppliers
                .Where(
                    rec => model == null
                    || rec.Id == model.Id
                    || rec.Email == model.Email && rec.Password == model.Password
                )
                .Select(rec => new SupplierViewModel
                {
                    Id = rec.Id,
                    SupplierFIO = rec.SupplierFIO,
                    Email = rec.Email,
                    Password = rec.Password
                })
                .ToList();
            }
        }
    }
}