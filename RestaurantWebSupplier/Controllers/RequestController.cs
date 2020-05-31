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
    public class RequestController : Controller
    {
        private readonly IRequestLogic requestLogic;
        private readonly IFridgeLogic fridgeLogic;
        public RequestController(IRequestLogic requestLogic, IFridgeLogic fridgeLogic)
        {
            this.requestLogic = requestLogic;
            this.fridgeLogic = fridgeLogic;
        }

        public IActionResult Request()
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            var кequests = requestLogic.Read(new RequestBindingModel
            {
                SupplierId = Program.Supplier.Id
            });
            return View(кequests);
        }

        public IActionResult RequestView(int ID)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (TempData["ErrorFoodReserve"] != null)
            {
                ModelState.AddModelError("", TempData["ErrorFoodReserve"].ToString());
            }
            ViewBag.RequestID = ID;
            var foods = requestLogic.Read(new RequestBindingModel
            {
                Id = ID
            })?[0].Foods;
            return View(foods);
        }

        public IActionResult ListFoodAvailable(int id, int count, string name, int requestId)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            ViewBag.FoodName = name;
            ViewBag.Count = count;
            ViewBag.FoodId = id;
            ViewBag.RequestId = requestId;
            var fridges = fridgeLogic.GetFridgeAvailable(new ReserveFoodsBindingModel
            {
                FoodId = id,
                Count = count
            });
            return View(fridges);
        }
    }
}