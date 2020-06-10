using System;
using System.Collections.Generic;
using System.Text;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.ViewModels;

namespace RestaurantBusinessLogic.Interfaces
{
    public interface IDishLogic
    {
        List<DishViewModel> Read(DishBindingModel model);
        void CreateOrUpdate(DishBindingModel model);
        void Delete(DishBindingModel model);
        void SaveJsonDish(string folderName);
        void SaveXmlDish(string folderName);
        void SaveJsonDishFood(string folderName);
        void SaveXmlDishFood(string folderName);
    }
}
