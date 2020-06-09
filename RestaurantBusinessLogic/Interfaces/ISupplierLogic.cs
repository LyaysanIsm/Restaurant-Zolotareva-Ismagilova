using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.Interfaces
{
    public interface ISupplierLogic
    {
        List<SupplierViewModel> Read(SupplierBindingModel model);
        void CreateOrUpdate(SupplierBindingModel model);
        void Delete(SupplierBindingModel model);
        void SaveJsonSupplier(string folderName);
        void SaveXmlSupplier(string folderName);
    }
}