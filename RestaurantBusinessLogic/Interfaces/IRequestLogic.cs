using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.Interfaces
{
    public interface IRequestLogic
    {
        List<RequestViewModel> Read(RequestBindingModel model);
        void CreateOrUpdate(RequestBindingModel model);
        void Delete(RequestBindingModel model);
        void Reserve(ReserveFoodsBindingModel model);
        void SaveJsonRequest(string folderName);
        void SaveJsonRequestFood(string folderName);
        void SaveXmlRequest(string folderName);
        void SaveXmlRequestFood(string folderName);
    }
}