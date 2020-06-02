using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.BusinessLogics;
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
        private readonly SupplierBusinessLogic supplierLogic;
        private readonly SupplierReportLogic reportLogic;
        public RequestController(IRequestLogic requestLogic, IFridgeLogic fridgeLogic, SupplierBusinessLogic supplierLogic, SupplierReportLogic reportLogic)
        {
            this.requestLogic = requestLogic;
            this.fridgeLogic = fridgeLogic;
            this.supplierLogic = supplierLogic;
            this.reportLogic = reportLogic;
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

        public IActionResult Reserve(int requestId, int foodId)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            supplierLogic.ReserveFoods(new ReserveFoodsBindingModel
            {
                RequestId = requestId,
                FoodId = foodId
            });
            return RedirectToAction("RequestView", new { id = requestId });
        }

        public IActionResult AcceptRequest(int id)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            supplierLogic.AcceptRequest(new ChangeRequestStatusBindingModel
            {
                RequestId = id
            });
            return RedirectToAction("Request");
        }

        public IActionResult CompleteRequest(int id)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            supplierLogic.CompleteRequest(new ChangeRequestStatusBindingModel
            {
                RequestId = id
            });
            return RedirectToAction("Request");
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
            var fridges = fridgeLogic.GetFridgeAvailable(new RequestFoodBindingModel
            {
                FoodId = id,
                Count = count
            });
            return View(fridges);
        }

        public IActionResult SendWordReport(int id)
        {
            var request = requestLogic.Read(new RequestBindingModel { Id = id }).FirstOrDefault();
            string fileName = "D:\\data\\" + request.Id + ".docx";
            reportLogic.SaveNeedFoodToWordFile(fileName, request, Program.Supplier.Login);
            return RedirectToAction("RequestView");
        }
        public IActionResult SendExcelReport(int id)
        {
            var request = requestLogic.Read(new RequestBindingModel { Id = id }).FirstOrDefault();
            string fileName = "D:\\data\\" + request.Id + ".xlsx";
            reportLogic.SaveNeedFoodToExcelFile(fileName, request, Program.Supplier.Login);
            return RedirectToAction("RequestView");
        }
    }
}