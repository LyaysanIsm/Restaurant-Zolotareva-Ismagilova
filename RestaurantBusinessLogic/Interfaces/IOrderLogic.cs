﻿using System;
using System.Collections.Generic;
using System.Text;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.ViewModels;

namespace RestaurantBusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);
        void CreateOrUpdate(OrderBindingModel model);
        void Delete(OrderBindingModel model);
        void SaveJson(string folderName);
        void SaveXml(string folderName);
    }
}
