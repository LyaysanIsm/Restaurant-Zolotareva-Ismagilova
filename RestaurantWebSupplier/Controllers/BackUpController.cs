using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBusinessLogic.BusinessLogics;
using RestaurantBusinessLogic.Interfaces;
using RestaurantDatabaseImplement.Implements;

namespace RestaurantWebSupplier.Controllers
{
    public class BackUpController : Controller
    {
        private readonly IRequestLogic _request;
        private readonly IFridgeLogic _fridge;
        private readonly ISupplierLogic _supplier;
        private readonly IFoodLogic _food;
        private readonly SupplierReportLogic _supplierReport;
        public BackUpController(IRequestLogic request, IFridgeLogic fridge, ISupplierLogic supplier, IFoodLogic food, SupplierReportLogic supplierReport)
        {
            _request = request;
            _fridge = fridge;
            _supplier = supplier;
            _food = food;
            _supplierReport = supplierReport;
        }
        public IActionResult BackUp()
        {
            return View();
        }
        public IActionResult BackUpToJson()
        {
            string fileName = "C:\\Users\\Lyays\\Desktop\\Backup\\BackupJson";
            if (Directory.Exists(fileName))
            {
                _request.SaveJsonRequest(fileName);
                _request.SaveJsonRequestFood(fileName);
                _fridge.SaveJsonFridge(fileName);
                _fridge.SaveJsonFridgeFood(fileName);
                _supplier.SaveJsonSupplier(fileName);
                _food.SaveJsonFood(fileName);
                _supplierReport.SendMailBackup("lyaysanlabs@gmail.com", fileName, "Бэкап Json", "json");
                return RedirectToAction("BackUp");
            }
            else
            {
                return RedirectToAction("BackUp");
            }
        }
        public IActionResult BackUpToXml()
        {
            string fileName = "C:\\Users\\Lyays\\Desktop\\Backup\\BackupXml";
            if (Directory.Exists(fileName))
            {
                _request.SaveXmlRequest(fileName);
                _request.SaveXmlRequestFood(fileName);
                _fridge.SaveXmlFridge(fileName);
                _fridge.SaveXmlFridgeFood(fileName);
                _supplier.SaveXmlSupplier(fileName);
                _food.SaveXmlFood(fileName);
                _supplierReport.SendMailBackup("lyaysanlabs@gmail.com", fileName, "Бэкап Xml", "xml");
                return RedirectToAction("BackUp");
            }
            else
            {
                return RedirectToAction("BackUp");
            }
        }
    }
}