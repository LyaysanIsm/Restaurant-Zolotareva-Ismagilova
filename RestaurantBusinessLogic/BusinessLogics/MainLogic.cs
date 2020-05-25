using RestaurantBusinessLogic.BindingModels;
using RestaurantBusinessLogic.Enums;
using RestaurantBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantBusinessLogic.BusinessLogics
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly IFridgeLogic fridgeLogic;

        public MainLogic(IOrderLogic orderLogic, IFridgeLogic fridgeLogic)
        {
            this.orderLogic = orderLogic;
            this.fridgeLogic = fridgeLogic;
        }

        public void CreateOrder(OrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                DishId = model.DishId,
                Count = model.Count,
                CreationDate = DateTime.Now,
                Status = Status.Принят
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];

            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }

            if (order.Status != Status.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }

            fridgeLogic.RemoveFoods(order);

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

        public void ReplanishFridge(ReserveFoodsBindingModel model)
        {
            fridgeLogic.AddFood(model);
        }
    }
}