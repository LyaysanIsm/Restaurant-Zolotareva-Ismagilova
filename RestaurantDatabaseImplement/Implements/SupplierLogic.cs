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
using Microsoft.EntityFrameworkCore;

namespace RestaurantDatabaseImplement.Implements
{
    public class SupplierLogic : ISupplierLogic
    {
        public void CreateOrUpdate(SupplierBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                Supplier element = context.Suppliers.FirstOrDefault(rec => rec.Login == model.Login && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Поставщик с таким логином уже существует");
                }
                if (model.Id.HasValue)
                {
                    element = context.Suppliers.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Поставщик не найден");
                    }
                }
                else
                {
                    element = new Supplier();
                    context.Suppliers.Add(element);
                }
                element.SupplierFIO = model.SupplierFIO;
                element.Login = model.Login;
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
                    throw new Exception("Поставщик не найден");
                }
            }
        }

        public List<SupplierViewModel> Read(SupplierBindingModel model)
        {
            using (var context = new RestaurantDatabase())
            {
                return context.Suppliers
                 .Where(rec => model == null || rec.Id == model.Id || (rec.Login == model.Login) &&
                 (model.Password == null || rec.Password == model.Password))
                .Select(rec => new SupplierViewModel
                {
                    Id = rec.Id,
                    SupplierFIO = rec.SupplierFIO,
                    Login = rec.Login,
                    Password = rec.Password
                })
                .ToList();
            }
        }

        public void SaveJsonSupplier(string folderName)
        {
            string fileName = $"{folderName}\\Supplier.json";
            using (var context = new RestaurantDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<Supplier>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Suppliers);
                }
            }
        }

        public void SaveXmlSupplier(string folderName)
        {
            string fileNameDop = $"{folderName}\\Supplier.xml";
            using (var context = new RestaurantDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Supplier>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Suppliers);
                }
            }
        }
    }
}