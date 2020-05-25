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
    public class SupplierLogic : ISupplierLogic
    {
        public void CreateOrUpdate(SupplierBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                Supplier element = context.Suppliers.FirstOrDefault(rec => rec.SupplierFIO == model.SupplierFIO && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("There is already a supplier with this username");
                }
                if (model.Id.HasValue)
                {
                    element = context.Suppliers.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Supplier not found");
                    }
                }
                else
                {
                    element = new Supplier();
                    context.Suppliers.Add(element);
                }
                element.SupplierFIO = model.SupplierFIO;
                element.Password = model.Password;
                element.Email = model.Email;
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
                    throw new Exception("Supplier not found");
                }
            }
        }

        public List<SupplierViewModel> Read(SupplierBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                return context.Suppliers
                .Where(rec => (rec.SupplierFIO == model.SupplierFIO) && (model.Password == null || rec.Password == model.Password))
                .Select(rec => new SupplierViewModel
                {
                    Id = rec.Id,
                    SupplierFIO = rec.SupplierFIO,
                    Password = rec.Password,
                    Email = rec.Email
                })
                .ToList();
            }
        }
    }
}