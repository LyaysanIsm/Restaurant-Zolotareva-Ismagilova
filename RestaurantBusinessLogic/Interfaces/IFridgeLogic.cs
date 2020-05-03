using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.Interfaces
{
    public interface IFridgeLogic
    {
        List<FridgeViewModel> GetList();
        FridgeViewModel GetElement(int id);
        void AddElement(FridgeBindingModel model);
        void UpdElement(FridgeBindingModel model);
        void DelElement(int id);
        void FillFridge(FridgeFoodBindingModel model);
    }
}