using RestaurantBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestaurantDatabaseImplement.Models
{
    public class Request
    {
        public int? Id { get; set; }
        public int SupplierId { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        [Required]
        public Status Status { get; set; }
        public Supplier Supplier { get; set; }
    }
}