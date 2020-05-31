using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantDatabaseImplement.Models;
using RestaurantWebSupplier.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebSupplier.Controllers
{
    public class FridgeController : Controller
    {
        private readonly IFridgeLogic fridgeLogic;
        private readonly IFoodLogic foodLogic;

        public FridgeController(IFridgeLogic fridgeLogic, IFoodLogic foodLogic)
        {
            this.fridgeLogic = fridgeLogic;
            this.foodLogic = foodLogic;
        }

        public IActionResult ListFridges()
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            var fridge = fridgeLogic.Read(new FridgeBindingModel
            {
                SupplierId = Program.Supplier.Id
            });
            return View(fridge);
        }

        public IActionResult Details(int? id)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.FridgeId = id;
            var foods = fridgeLogic.Read(new FridgeBindingModel
            {
                Id = id
            })?[0].Foods;
            return View(foods);
        }

        public IActionResult CreateFridge()
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFridge([Bind("FridgeName,Capacity,Type")] Fridge fridge)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    fridgeLogic.CreateOrUpdate(new FridgeBindingModel
                    {
                        FridgeName = fridge.FridgeName,
                        Capacity = fridge.Capacity,
                        Type = fridge.Type,
                        SupplierId = Program.Supplier.Id
                    });
                    return RedirectToAction(nameof(ListFridges));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(fridge);
        }

        public IActionResult ChangeFridge(int? id)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (id == null)
            {
                return NotFound();
            }
            var fridge = fridgeLogic.Read(new FridgeBindingModel
            {
                Id = id
            })?[0];
            if (fridge == null)
            {
                return NotFound();
            }
            return View(new Fridge
            {
                Id = id.Value,
                FridgeName = fridge.FridgeName,
                Capacity = fridge.Capacity,
                Type = fridge.Type
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeFridge(int id, [Bind("Id,FridgeName,Capacity,Type")] Fridge fridge)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (id != fridge.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    fridgeLogic.CreateOrUpdate(new FridgeBindingModel
                    {
                        Id = id,
                        FridgeName = fridge.FridgeName,
                        Capacity = fridge.Capacity,
                        Type = fridge.Type,
                        SupplierId = Program.Supplier.Id
                    });
                }
                catch (Exception exception)
                {
                    if (!FridgeExists(fridge.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", exception.Message);
                        return View(fridge);
                    }
                }
                return RedirectToAction(nameof(ListFridges));
            }
            return View(fridge);
        }

        public IActionResult DeleteFridge(int? id)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (id == null)
            {
                return NotFound();
            }
            var fridge = fridgeLogic.Read(new FridgeBindingModel
            {
                Id = id
            })?[0];
            if (fridge == null)
            {
                return NotFound();
            }
            return View(new Fridge
            {
                Id = id.Value,
                FridgeName = fridge.FridgeName,
                Capacity = fridge.Capacity,
                Type = fridge.Type
            });
        }

        [HttpPost, ActionName("DeleteFridge")]
        [ValidateAntiForgeryToken]
        public IActionResult Completion(int id)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            fridgeLogic.Delete(new FridgeBindingModel
            {
                Id = id
            });
            return RedirectToAction(nameof(ListFridges));
        }

        private bool FridgeExists(int id)
        {
            return fridgeLogic.Read(new FridgeBindingModel
            {
                Id = id
            }).Count == 1;
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
                catch (Exception exception)
                {
                    TempData["ErrorLackInFridge"] = exception.Message;
                    return RedirectToAction("AddFood", "Food", new
                    {
                        foodId = model.FoodId,
                        fridgeId = model.FridgeId
                    });
                }
            }
            return RedirectToAction("Details", new { id = model.FridgeId });
        }

        public IActionResult ReserveFoods(int fridgeId, int foodId, int count, int requestId)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            try
            {
                fridgeLogic.ReserveFoods(new ReserveFoodsBindingModel
                {
                    FridgeId = fridgeId,
                    FoodId = foodId,
                    Count = count
                });
            }
            catch (Exception ex)
            {
                TempData["ErrorFoodReserve"] = ex.Message;
                return RedirectToAction("RequestView", "Request", new { id = requestId });
            }
            return RedirectToAction("RequestView", "Request", new { id = requestId });
        }
    }
}