using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestaurantDatabaseImplement.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierFIO { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [ForeignKey("SupplierId")]
        public virtual List<Fridge> Fridges { get; set; }
        [ForeignKey("SupplierId")]
        public virtual List<Request> Requests { get; set; }
    }
}