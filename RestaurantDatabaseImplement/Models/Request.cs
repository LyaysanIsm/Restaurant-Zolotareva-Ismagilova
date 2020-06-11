using RestaurantBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestaurantDatabaseImplement.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        [Required]
        public RequestStatus Status { get; set; }
        [ForeignKey("RequestId")]
        public virtual List<RequestFood> RequestFoods { get; set; }
        public virtual Supplier Supplier { get; set; }
        public DateTime CompletionDate { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public decimal Sum { get; set; }
    }
}