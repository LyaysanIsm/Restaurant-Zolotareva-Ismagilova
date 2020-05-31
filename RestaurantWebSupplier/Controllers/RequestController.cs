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
        public RequestController(IRequestLogic requestLogic)
        {
            this.requestLogic = requestLogic;
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
            ViewBag.RequestID = ID;
            var foods = requestLogic.Read(new RequestBindingModel
            {
                Id = ID
            })?[0].Foods;
            return View(foods);
        }

        public IActionResult ReserveFoods(int? FoodId, int? FridgeId)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (FoodId == null && FridgeId == null)
            {
                return NotFound();
            }
            if (TempData["ErrorLackFoods"] != null)
            {
                ModelState.AddModelError("", TempData["ErrorLackFoods"].ToString());
            }
            var request = requestLogic.Read(new RequestBindingModel
            {
                Id = FoodId
            })?[0];
            if (request == null)
            {
                return NotFound();
            }
            return View(new ReserveFoodsBindingModel
            {
                FoodId = FoodId.Value,
                FridgeId = FridgeId.Value,
            });
        }
    }
}