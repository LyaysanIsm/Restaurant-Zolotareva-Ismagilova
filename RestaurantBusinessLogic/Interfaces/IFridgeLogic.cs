using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.Interfaces
{
    public interface IFridgeLogic
    {
        List<FridgeViewModel> Read(FridgeBindingModel model);
        void CreateOrUpdate(FridgeBindingModel model);
        void Delete(FridgeBindingModel model);
        void AddFood(RequestFoodBindingModel model);
        void ReserveFoods(RequestFoodBindingModel model);
        List<FridgeAvailableViewModel> GetFridgeAvailable(RequestFoodBindingModel model);
        void SaveJsonFridge(string folderName);
        void SaveJsonFridgeFood(string folderName);
        void SaveXmlFridge(string filderName);
        void SaveXmlFridgeFood(string filderName);
    }
}