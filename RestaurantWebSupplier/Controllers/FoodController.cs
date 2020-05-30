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
        private readonly IFridgeLogic fridgeLogic;

        public FoodController(IFoodLogic foodLogic, IFridgeLogic fridgeLogic)
        {
            this.foodLogic = foodLogic;
            this.fridgeLogic = fridgeLogic;
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
            return View(new ReserveFoodsBindingModel
            {
                FoodId = FoodId.Value,
                FridgeId = FridgeId.Value,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFood([Bind("FridgeId, FoodId, Count")] ReserveFoodsBindingModel model)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    fridgeLogic.AddFood(model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return RedirectToAction("AddFood", "Food", new
                    {
                        FoodID = model.FoodId,
                        FridgeID = model.FridgeId
                    });
                }
            }
            return RedirectToAction("Details", new { id = model.FridgeId });
        }
    }
}