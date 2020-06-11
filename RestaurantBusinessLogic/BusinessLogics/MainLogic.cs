using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Enums;
using RestaurantBusinessLogic.Interfaces;
using RestaurantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BusinessLogics
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly IRequestLogic requestLogic;
        private readonly IDishLogic dishLogic;

        public MainLogic(IOrderLogic orderLogic, IRequestLogic requestLogic, IDishLogic dishLogic)
        {
            this.orderLogic = orderLogic;
            this.requestLogic = requestLogic;
            this.dishLogic = dishLogic;
        }

        public void CreateOrder(OrderBindingModel order)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                DishId = order.DishId,
                Count = order.Count,
                CreationDate = DateTime.Now,
                Status = Status.Принят
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            var request = requestLogic.Read(new RequestBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }

            if (order.Status != Status.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }

            if (request.Status != RequestStatus.Готова)
            {
                throw new Exception("Продукты ещё не доставлены");
            }

            requestLogic.CreateOrUpdate(new RequestBindingModel
            {
                Status = RequestStatus.Обработана
            });

            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                DishId = order.DishId,
                Count = order.Count,
                Sum = order.Sum,
                CreationDate = order.CreationDate,
                Status = Status.Выполняется
            });
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != Status.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                DishId = order.DishId,
                Count = order.Count,
                Sum = order.Sum,
                CreationDate = order.CreationDate,
                CompletionDate = DateTime.Now,
                Status = Status.Готов
            });
        }

        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != Status.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                DishId = order.DishId,
                Count = order.Count,
                Sum = order.Sum,
                CreationDate = order.CreationDate,
                CompletionDate = order.CompletionDate,
                Status = Status.Оплачен
            });
        }

        public void CreateOrUpdateRequest(RequestBindingModel model)
        {
            requestLogic.CreateOrUpdate(new RequestBindingModel
            {
                Id = model.Id,
                SupplierId = model.SupplierId,
                Status = RequestStatus.Создана,
                Foods = model.Foods,                
                CreationDate = DateTime.Now
            });
        }

        public List<ReportDishFoodViewModel> GetDishFoodsOrder()
        {
            var dishes = dishLogic.Read(null);
            var list = new List<ReportDishFoodViewModel>();
            foreach (var dish in dishes)
            {
                foreach (var pc in dish.DishFoods)
                {
                    var record = new ReportDishFoodViewModel
                    {
                        DishName = dish.DishName,
                        FoodName = pc.Value.Item1,
                        Count = pc.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }
    }
}