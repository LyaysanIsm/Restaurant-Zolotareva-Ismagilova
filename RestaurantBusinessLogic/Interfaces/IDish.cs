using System;
using System.Collections.Generic;
using System.Text;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.ViewModels;

namespace RestaurantBusinessLogic.Interfaces
{
    public interface IDish
    {
        List<DishViewModel> Read(DishBindingModel model);
        void CreateOrUpdate(DishBindingModel model);
        void Delete(DishBindingModel model);
    }
}
