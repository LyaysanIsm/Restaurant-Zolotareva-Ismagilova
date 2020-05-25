using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantWebSupplier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebSupplier.Controllers
{
    public class RequestController
    {
        private readonly IRequestLogic _requestLogic;
        private readonly IFoodLogic _foodLogic;

        public RequestController(IRequestLogic requestLogic, IFoodLogic foodLogic)
        {
            _requestLogic = requestLogic;
            _foodLogic = foodLogic;
        }
        /*
        public IActionResult Request()
        {
            var requests = _requestLogic.Read(new RequestBindingModel
            {
                SupplierId = Program.Supplier.Id
            });
            var requestModels = new List<RequestModel>();
            foreach (var request in requests)
            {
                var foods = new List<RequestFoodModel>();
                foreach (var food in request.Foods)
                {
                    var foodata = _foodLogic.Read(new FoodBindingModel
                    {
                        Id = food.Key
                    }).FirstOrDefault();
                }
            }
        }*/
    }
}