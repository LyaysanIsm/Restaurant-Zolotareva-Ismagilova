﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BindingModels
{
    public class Food
    {
        public int? Id { get; set; }
        public string FoodName { get; set; }
        public decimal Price { get; set; }
    }
}