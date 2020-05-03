using System;
using System.Collections.Generic;
using System.Text;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.ViewModels;

namespace RestaurantBusinessLogic.Interfaces
{
    public interface IFood
    {
        List<FoodViewModel> Read(FoodBindingModel model);
        void CreateOrUpdate(FoodBindingModel model);
        void Delete(FoodBindingModel model);
    }
}
