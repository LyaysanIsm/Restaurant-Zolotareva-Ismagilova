using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Interfaces;

namespace RestaurantWebSupplier.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodLogic foodLogic;

        public FoodController(IFoodLogic foodLogic)
        {
            this.foodLogic = foodLogic;
        }

        public IActionResult ListFoods(int fridgeId)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            ViewBag.fridgeId = fridgeId;
            return View(foodLogic.Read(null));
        }

        public IActionResult AddFood(int? FoodId, int? FridgeId)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (FoodId == null && FridgeId == null)
            {
                return NotFound();
            }
            if (TempData["ErrorLackInFridge"] != null)
            {
                ModelState.AddModelError("", TempData["ErrorLackInFridge"].ToString());
            }
            var food = foodLogic.Read(new FoodBindingModel
            {
                Id = FoodId
            })?[0];
            if (food == null)
            {
                return NotFound();
            }
            ViewBag.FoodName = food.FoodName;
            ViewBag.FridgeId = FridgeId;
            return View(new RequestFoodBindingModel
            {
                FoodId = FoodId.Value,
                FridgeId = FridgeId.Value,
            });
        }
    }
}