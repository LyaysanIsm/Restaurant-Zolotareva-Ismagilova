using Microsoft.AspNetCore.Mvc;
using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Interfaces;
using RestaurantDatabaseImplement.Models;
using RestaurantWebSupplier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebSupplier.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierLogic supplierLogic;

        public SupplierController(ISupplierLogic supplierLogic)
        {
            this.supplierLogic = supplierLogic;
        }

        public IActionResult Logout()
        {
            Program.Supplier = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel supplier)
        {
            if (String.IsNullOrEmpty(supplier.Login)
                || String.IsNullOrEmpty(supplier.Password))
            {
                return View(supplier);
            }
            var supplierView = supplierLogic.Read(new SupplierBindingModel
            {
                Login = supplier.Login,
                Password = supplier.Password
            }).FirstOrDefault();
            if (supplierView == null)
            {
                ModelState.AddModelError("", "Неверный логин или пароль");
                return View(supplier);
            }
            Program.Supplier = supplierView;
            return RedirectToAction("Request", "Request");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationModel supplier)
        {
            if (!ModelState.IsValid)
            {
                return View(supplier);
            }
            if (String.IsNullOrEmpty(supplier.SupplierFIO)
            || String.IsNullOrEmpty(supplier.Login)
            || String.IsNullOrEmpty(supplier.Password))
            {
                return View(supplier);
            }
            try
            {
                supplierLogic.CreateOrUpdate(new SupplierBindingModel
                {
                    SupplierFIO = supplier.SupplierFIO,
                    Login = supplier.Login,
                    Password = supplier.Password
                });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Такая почта уже существует", ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}