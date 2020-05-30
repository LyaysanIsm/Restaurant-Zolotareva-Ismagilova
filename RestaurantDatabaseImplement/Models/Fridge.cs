using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestaurantDatabaseImplement.Models
{
    public class Fridge
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Заполните поле")]
        [DisplayName("Название")]
        public string FridgeName { get; set; }
        [Required(ErrorMessage = "Заполните поле")]
        [DisplayName("Вместимость")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Заполните поле")]
        [DisplayName("Тип")]
        public string Type { get; set; }
        [ForeignKey("FridgeId")]
        public virtual List<FridgeFood> FridgeFoods { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}