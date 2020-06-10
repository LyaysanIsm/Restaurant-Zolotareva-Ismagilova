using RestaurantBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RestaurantBusinessLogic.ViewModels
{
    public class RequestViewModel
    {
        [DisplayName("Номер заявки")]
        public int Id { get; set; }
        public int SupplierId { get; set; }
        [DisplayName("ФИО")]
        public string SupplierFIO { get; set; }
        [DisplayName("Статус")]
        public RequestStatus Status { get; set; }
        [DisplayName("Дата создания")]
        public DateTime CreationDate { get; set; }
        public Dictionary<int, (string, int, bool)> Foods { get; set; }
        [DisplayName("Дата выполнения")]
        public DateTime? CompletionDate { get; set; }
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
    }
}