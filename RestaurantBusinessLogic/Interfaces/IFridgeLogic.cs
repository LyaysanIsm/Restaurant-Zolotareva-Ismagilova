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
        void AddFood(FridgeFoodBindingModel model);
        void RemoveFromFridge(OrderViewModel model);
    }
}