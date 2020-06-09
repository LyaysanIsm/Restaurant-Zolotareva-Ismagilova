﻿using System;
using System.Collections.Generic;
using System.Text;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.ViewModels;

namespace RestaurantBusinessLogic.Interfaces
{
    public interface IFoodLogic
    {
        List<FoodViewModel> Read(FoodBindingModel model);
        void CreateOrUpdate(FoodBindingModel model);
        void Delete(FoodBindingModel model);
        void SaveJsonFood(string folderName);
        void SaveXmlFood(string folderName);
    }
}
