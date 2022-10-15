
using Microsoft.EntityFrameworkCore;
using Restaurant.Service.ServerAPI.Models.Entities;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Restaurant.Service.ServerAPI.Database
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> optionBuilder) : base(optionBuilder) 
        {
            
        }        
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<MenuCategory>? MenuCategories { get; set; }
        public DbSet<Menu>? Menues { get; set; }
        public DbSet<CustomerTable>? CustomerTables { get; set; }
        public DbSet<Phone>? Phones { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<PurchasedOrder>? PurchasedOrders { get; set; }
        public DbSet<Basket>? Baskets { get; set; }
        public DbSet<PurchasedMenu>? PurchasedMenues { get; set; }
        public DbSet<Cook>? Cooks { get; set; }
        public DbSet<Receiver>? Receivers { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Position>? Positions { get; set; }
        public DbSet<QuantityStatus>? QuantityStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CredencialCode);
                entity.Property(e => e.CredencialCode).HasMaxLength(4).IsRequired();

                entity.Property(e => e.CustomerCount).IsRequired();

                entity.Property(e => e.TimeCheckIn).IsRequired();

                entity.Property(e => e.TimeCheckOut);

                entity.Property(e => e.TotalPrice).HasColumnType("money").HasConversion<double>().IsRequired();

                entity.Property(e => e.IsDone).IsRequired();

                entity.HasMany(e => e.PurchasedOrders).WithOne(e => e.Customer).HasForeignKey(e => e.CredencialCode).IsRequired();

                entity.HasMany(e => e.Baskets).WithOne(e => e.Customer).HasForeignKey(e => e.CustomerId).IsRequired();
            });
            modelBuilder.Entity<MenuCategory>(entity => 
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.NameCategory).HasMaxLength(64).IsRequired();

                entity.HasMany(e => e.Menus).WithOne(e => e.MenuCategory).HasForeignKey(e => e.MenuCategoryId).IsRequired();
            });
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.NameMenu).HasMaxLength(64).IsRequired();

                entity.Property(e => e.Price).HasColumnType("money").HasConversion<double>().IsRequired();

                entity.Property(e => e.UriImage).HasMaxLength(64).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(512).IsRequired();
                entity.HasOne(e=>e.MenuCategory).WithMany(e=>e.Menus).HasForeignKey(e=>e.MenuCategoryId).IsRequired();
                entity.HasMany(e => e.PurchasedMenus).WithOne(e => e.Menu).HasForeignKey(e => e.MenuNameId).IsRequired();

            });
            modelBuilder.Entity<CustomerTable>(entity => 
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Address).HasMaxLength(64).IsRequired();
                entity.Property(e => e.NumberTable).HasMaxLength(3).IsRequired();

                entity.Property(e => e.IsReserved).IsRequired();
                entity.HasMany(e => e.Baskets).WithOne(e => e.CustomerTable).HasForeignKey(e => e.CustomerTableId).IsRequired();
            });
            modelBuilder.Entity<Phone>(entity => 
            {
                entity.HasKey(e => e.PhoneNumber);

                entity.Property(e=> e.PhoneNumber).HasMaxLength(10).IsRequired();

                entity.HasOne(e => e.Employee).WithMany(e => e.Phones).HasForeignKey(e => e.EmployeeId).IsRequired();
                entity.Property(e => e.EmployeeId).HasMaxLength(64).IsRequired();

            });
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasMaxLength(64).IsRequired();

                entity.Property(e => e.FistName).HasMaxLength(64).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(64).IsRequired();  

                entity.Property(e => e.RegisterDate).HasMaxLength(64).IsRequired();

                entity.Property(e => e.Email).HasMaxLength(64).IsRequired();

                entity.Property(e => e.PasswordId).HasMaxLength(64).IsRequired();
                entity.HasMany(e => e.Cooks).WithOne(e => e.Employee).HasForeignKey(e => e.EmployeeId).IsRequired();
                entity.HasMany(e => e.Receivers).WithOne(e => e.Employee).HasForeignKey(e => e.EmployeeId).IsRequired();


            });
            modelBuilder.Entity<PurchasedOrder>(entity => 
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.TableName).HasMaxLength(64).IsRequired();
                entity.Property(e => e.ReceiveAccept).IsRequired();

                entity.Property(e => e.CustomerAccept).IsRequired();

                entity.Property(e => e.AllFoodOrderFinished).IsRequired();

                entity.Property(e => e.TotalPrice).HasColumnType("money").HasConversion<double>().IsRequired();

                entity.Property(e => e.PurchasedTime).IsRequired();

                entity.HasOne(e => e.Receiver).WithMany(e => e.PurchasedOrders).HasForeignKey(e => e.ReceiverId);
                entity.Property(e => e.ReceiverId).HasMaxLength(64);
                entity.HasOne(e => e.Cook).WithMany(e => e.PurchasedOrders).HasForeignKey(e => e.CookId);
                entity.Property(e => e.CookId).HasMaxLength(64);
                entity.HasOne(e => e.Customer).WithMany(e => e.PurchasedOrders).HasForeignKey(e => e.CredencialCode).IsRequired();
                entity.Property(e => e.CredencialCode).HasMaxLength(4).IsRequired();
                entity.HasMany(e => e.PurchasedMenus).WithOne(e => e.PurchasedOrder).HasForeignKey(e => e.PurchasedOrderId);


            });
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CustomerTableId).IsRequired();
                entity.Property(e=>e.CustomerId).HasMaxLength(4).IsRequired();
                entity.HasOne(e => e.CustomerTable).WithMany(e => e.Baskets).HasForeignKey(e => e.CustomerTableId).IsRequired();
                entity.HasOne(e => e.Customer).WithMany(e => e.Baskets).HasForeignKey(e => e.CustomerId).IsRequired();
                entity.HasMany(e => e.PurchasedMenus).WithOne(e => e.Basket).HasForeignKey(e => e.BasketId).IsRequired();
            });
            modelBuilder.Entity<PurchasedMenu>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Note).HasMaxLength(64).IsRequired();
                entity.Property(e=> e.IsPurchased).IsRequired();
                entity.Property(e => e.BasketId).IsRequired();
                entity.Property(e => e.MenuNameId).IsRequired();
                entity.HasMany(e => e.QuantityStatuses).WithOne(e => e.PurchasedMenu).HasForeignKey(e => e.PurchasedMenuId).IsRequired();
                entity.HasOne(e => e.Basket).WithMany(e => e.PurchasedMenus).HasForeignKey(e => e.BasketId).IsRequired();
                entity.HasOne(e => e.Menu).WithMany(e => e.PurchasedMenus).HasForeignKey(e => e.MenuNameId).IsRequired();
                entity.HasOne(e => e.PurchasedOrder).WithMany(e => e.PurchasedMenus).HasForeignKey(e => e.PurchasedOrderId);
            });
            modelBuilder.Entity<Cook>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e=>e.DepartmentId).HasMaxLength(64).IsRequired();
                entity.Property(e => e.PositionId).HasMaxLength(64).IsRequired();
                entity.Property(e => e.EmployeeId).HasMaxLength(64).IsRequired();
                entity.HasMany(e => e.PurchasedOrders).WithOne(e => e.Cook).HasForeignKey(e => e.CookId);
                entity.HasOne(e => e.Position).WithMany(e => e.Cooks).HasForeignKey(e => e.PositionId).IsRequired();
                entity.HasOne(e => e.Department).WithMany(e => e.Cooks).HasForeignKey(e => e.DepartmentId).IsRequired();
                entity.HasOne(e => e.Employee).WithMany(e => e.Cooks).HasForeignKey(e => e.EmployeeId).IsRequired();
            });
            modelBuilder.Entity<Receiver>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.EmployeeId).HasMaxLength(64).IsRequired();
                entity.Property(e => e.PositionId).HasMaxLength(64).IsRequired();
                entity.Property(e => e.DepartmentId).HasMaxLength(64).IsRequired();
                entity.HasMany(e => e.PurchasedOrders).WithOne(e => e.Receiver).HasForeignKey(e => e.ReceiverId);
                entity.HasOne(e => e.Employee).WithMany(e => e.Receivers).HasForeignKey(e => e.EmployeeId).IsRequired();
                entity.HasOne(e => e.Position).WithMany(e => e.Receivers).HasForeignKey(e => e.PositionId).IsRequired();
                entity.HasOne(e => e.Department).WithMany(e => e.Receivers).HasForeignKey(e => e.DepartmentId).IsRequired();
            });
            modelBuilder.Entity<Department>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Cooks).WithOne(e => e.Department).HasForeignKey(e => e.DepartmentId).IsRequired();
                entity.HasMany(e => e.Receivers).WithOne(e => e.Department).HasForeignKey(e => e.DepartmentId).IsRequired();
            });
            modelBuilder.Entity<Position>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e =>e.Salary).IsRequired();
                entity.Property(e => e.WorkingTimeIn).IsRequired();
                entity.Property(e => e.WorkingTimeOut).IsRequired();
                entity.HasMany(e => e.Cooks).WithOne(e => e.Position).HasForeignKey(e => e.PositionId).IsRequired();
                entity.HasMany(e => e.Receivers).WithOne(e => e.Position).HasForeignKey(e => e.PositionId).IsRequired();
            });
            modelBuilder.Entity<QuantityStatus>(entity => 
            {
                entity.HasKey(e=>e.Id);
                entity.Property(e => e.IsFinish).IsRequired();
                entity.Property(e => e.PurchasedMenuId).IsRequired();
                entity.HasOne(e => e.PurchasedMenu).WithMany(e => e.QuantityStatuses).HasForeignKey(e => e.PurchasedMenuId).IsRequired();
            });
        }


    }
}
