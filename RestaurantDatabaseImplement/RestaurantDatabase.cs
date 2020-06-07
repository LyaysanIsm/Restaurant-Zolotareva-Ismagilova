using RestaurantDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantDatabaseImplement
{
    class RestaurantDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                //optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-0755RO83\SQLEXPRESS;Initial Catalog=RestaurantDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-IMFQ926R\SQLEXPRESS;Initial Catalog=RestaurantDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Food> Foods { set; get; }
        public virtual DbSet<Dish> Dishes { set; get; }
        public virtual DbSet<DishFood> DishFoods { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Fridge> Fridges { set; get; }
        public virtual DbSet<FridgeFood> FridgeFoods { set; get; }
        public virtual DbSet<Request> Requests { set; get; }
        public virtual DbSet<RequestFood> RequestFoods { set; get; }
        public virtual DbSet<Supplier> Suppliers { set; get; }
    }
}
