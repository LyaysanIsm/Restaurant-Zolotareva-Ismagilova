using RestaurantBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RestaurantBusinessLogic.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DisplayName("Дата создания")]
        public DateTime CreationDate { get; set; }
        [DisplayName("Дата завершения")]
        public DateTime? CompletionDate { get; set; }
        [DisplayName("Статус")]
        public Status Status { get; set; }
        public int DishId { get; set; }
        public string DishName { get; set; }
    }
}