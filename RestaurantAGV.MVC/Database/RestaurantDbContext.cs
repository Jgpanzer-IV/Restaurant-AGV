using Microsoft.EntityFrameworkCore;
using RestaurantAGV.MVC.Models.Entities;


namespace RestaurantAGV.MVC.Database;
public class RestaurantDbContext : DbContext{

    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) 
    {}
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<MenuCategory>? MenuCategories { get; set; }
        public DbSet<Menu>? Menues { get; set; }
        public DbSet<Table>? Tables { get; set; }
        public DbSet<Phone>? Phones { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<PurchasedOrder>? PurchasedOrders { get; set; }
        public DbSet<Basket>? Baskets { get; set; }
        public DbSet<PurchasedMenu>? PurchasedMenues { get; set; }
        public DbSet<Cook>? Cooks { get; set; }
        public DbSet<Receiver>? Receivers { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Position>? Positions { get; set; }
        public DbSet<MenusStatus>? QuantityStatuses { get; set; }
        public DbSet<AGVStatus>? AGVsStatus { get; set; } 
        public DbSet<SelectedMenu>? SelectedMenus {get;set;}
        public DbSet<BillOrder>? BillOrders {get;set;}
        public DbSet<MenusStatus>? MenusStatus {get;set;}


    protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasMaxLength(4).IsRequired();
                entity.Property(e => e.CustomerCount).IsRequired();
                entity.Property(e => e.TimeCheckIn).IsRequired();
                entity.Property(e => e.TimeCheckOut);
                entity.Property(e => e.BillingDone).IsRequired();

                entity.HasMany(e => e.PurchasedOrders).WithOne(e => e.Customer).HasForeignKey(e => e.CustomerId).IsRequired();
                entity.HasOne(e => e.Basket).WithOne(e => e.Customer);
                entity.HasOne(e => e.BillOrder).WithOne(e=>e.Customer);
                entity.HasOne(e => e.Table).WithMany(e => e.Customers).HasForeignKey(e => e.TableId).IsRequired();
            });
            builder.Entity<MenuCategory>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CategoryName).HasMaxLength(64).IsRequired();
                entity.HasMany(e => e.Menus).WithOne(e => e.MenuCategory).HasForeignKey(e => e.MenuCategoryId).IsRequired();

                entity.HasData(new MenuCategory[]{
                    new(){
                        Id = 1,
                        CategoryName = "Meat",
                    },
                    new(){
                        Id = 2,
                        CategoryName = "Meat with Vegetable"
                    },
                    new(){
                        Id = 3,
                        CategoryName = "Vegetable"
                    },
                    new(){
                        Id = 4,
                        CategoryName = "Seafood"
                    },
                    new(){
                        Id = 5,
                        CategoryName = "Seafood with Vegetable"
                    },
                    new(){
                        Id = 6,
                        CategoryName = "Dessert"
                    },
                    new(){
                        Id = 7,
                        CategoryName = "Drink"
                    }


                });
            });
            builder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MenuName).HasMaxLength(64).IsRequired();
                entity.Property(e => e.Price).HasColumnType("money").HasConversion<double>().IsRequired();
                entity.Property(e => e.UriImage).HasMaxLength(64).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(512).IsRequired();

                entity.HasOne(e=>e.MenuCategory).WithMany(e=>e.Menus).HasForeignKey(e=>e.MenuCategoryId).IsRequired();
                entity.HasMany(e => e.PurchasedMenus).WithOne(e => e.Menu).HasForeignKey(e => e.MenuNameId).IsRequired();
                entity.HasMany(e=>e.SelectedMenus).WithOne(e=>e.Menu).HasForeignKey(e => e.MenuId).IsRequired();

                entity.HasData(new Menu[]{
                    new(){
                        Id = 1,
                        MenuCategoryId = 1,
                        MenuName = "Fried Pork with Garlic Pepper",
                        UriImage = "/images/fried-pork-with-garlic-pepper.jpg",
                        Price = 19.45M,
                        Description = "This menu have created from the principle of Saral Castle."
                    },
                    new (){
                        Id = 2,
                        MenuCategoryId = 5,
                        MenuName = "American Shrimp Fried Rice",
                        UriImage = "/images/american-shrimp-fried-rice.jpg",
                        Price = 5.25M,
                        Description = "If you are not looking for special time, Then this is right for you."
                    },
                    new() {
                        Id = 3,
                        MenuCategoryId = 3,
                        MenuName = "Fried Spring Rolls",
                        UriImage = "/images/fried-spring-rolls.jpg",
                        Price = 12.2M,
                        Description = "This rolling spring will give you a special time and improve your healty."
                    },
                    new(){
                        Id = 4,
                        MenuCategoryId = 2,
                        MenuName = "Stir Fried Kale Spicy Crispy Pork",
                        UriImage = "/images/stir-fried-kale-spicy-crispy-pork.jpg",
                        Price = 7.66M,
                        Description = "The vegetable with pork combind each other as well from Thailand."
                    },
                    new(){
                        Id = 5,
                        MenuCategoryId = 7,
                        MenuName = "Coffee with Pearl",
                        UriImage = "/images/coffee-drink.jpg",
                        Price = 4.23M,
                        Description = "The coffee selected from the true nature to serve the best for you."
                    },
                    new(){
                        Id = 6,
                        MenuCategoryId = 7,
                        MenuName = "Green tea with Milk",
                        UriImage = "/images/green-tea-drink.jpg",
                        Price = 3.32M,
                        Description = "This green tea have no caffeine as a component."
                    },
                    new(){
                        Id = 7,
                        MenuCategoryId = 7,
                        MenuName = "Orange juice",
                        UriImage = "/images/orange-drink.jpg",
                        Price = 2.89M,
                        Description = "This is a menu for who need to improve their healty."
                    },
                    new(){
                        Id = 8,
                        MenuCategoryId = 6,
                        MenuName = "Chocolat Cake",
                        UriImage = "/images/sweet-chocolet-cake.jpg",
                        Price = 4.42M,
                        Description = "For anyone who love chocolat."
                    }, 
                    new (){
                        Id = 9,
                        MenuCategoryId = 6,
                        MenuName = "Molten Cake",
                        UriImage = "/images/sweet-molten-cake.jpg",
                        Price = 6.64M,
                        Description = "This cake is for the anyone who want to have a special time with dessert."
                    },
                    new(){
                        Id = 10,
                        MenuCategoryId = 6,
                        MenuName = "Yuan Assortment",
                        UriImage = "/images/sweet-tang-yuan-assortment.jpg",
                        Price = 5.23M,
                        Description = "The dessert from the chainaland."
                    },
                    new() {
                        Id = 11,
                        MenuCategoryId = 6,
                        MenuName = "Yuan Composition",
                        UriImage = "/images/sweet-tang-yuan-composition.jpg",
                        Price = 4.68M,
                        Description = "The Original Dessert from chainaland"
                    
                    }

                });
            });
            builder.Entity<Table>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Address).HasMaxLength(64).IsRequired();
                entity.Property(e => e.NumberTable).HasMaxLength(3).IsRequired();
                entity.Property(e => e.ChairQuantity).IsRequired();
                entity.Property(e => e.DistantMeter).IsRequired();
                entity.Property(e => e.IsReserved).IsRequired();

                entity.HasMany(e => e.Customers).WithOne(e => e.Table).HasForeignKey(e => e.TableId).IsRequired();

                entity.HasData(new Table[]{
                    new(){
                        Id = 1,
                        ChairQuantity = 4,
                        DistantMeter = 30,
                        IsReserved = false,
                        NumberTable = "01",
                        Address = "In Room"
                    },
                    new(){
                        Id = 2,
                        ChairQuantity = 4,
                        DistantMeter = 40,
                        IsReserved = false,
                        NumberTable = "02",
                        Address = "In Room"
                    },
                    new(){
                        Id = 3,
                        ChairQuantity = 4,
                        DistantMeter = 60,
                        IsReserved = false,
                        NumberTable = "03",
                        Address = "In Room"
                    },                    
                    new(){
                        Id = 4,
                        ChairQuantity = 4,
                        DistantMeter = 70,
                        IsReserved = false,
                        NumberTable = "04",
                        Address = "In Room"
                    },
                    new(){
                        Id = 5,
                        ChairQuantity = 2,
                        DistantMeter = 100,
                        IsReserved = false,
                        NumberTable = "01",
                        Address = "Out Door"
                    },
                    new(){
                        Id = 6,
                        ChairQuantity = 2,
                        DistantMeter = 120,
                        IsReserved = false,
                        NumberTable = "02",
                        Address = "Out Door"
                    }




                });
            });
            builder.Entity<Phone>(entity => 
            {
                entity.HasKey(e => e.PhoneNumber);
                entity.Property(e=> e.PhoneNumber).HasMaxLength(10).IsRequired();
                entity.HasOne(e => e.Employee).WithMany(e => e.Phones).HasForeignKey(e => e.EmployeeId).IsRequired();
                entity.Property(e => e.EmployeeId).HasMaxLength(64).IsRequired();
            });
            builder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasMaxLength(64).IsRequired();

                entity.Property(e => e.FistName).HasMaxLength(64).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(64).IsRequired();  
                entity.Property(e => e.RegisterDate).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(64).IsRequired();
                entity.Property(e => e.Password).HasMaxLength(64).IsRequired();

                entity.HasMany(e => e.Cooks).WithOne(e => e.Employee).HasForeignKey(e => e.EmployeeId).IsRequired();
                entity.HasMany(e => e.Receivers).WithOne(e => e.Employee).HasForeignKey(e => e.EmployeeId).IsRequired();
            });
            builder.Entity<PurchasedOrder>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ReceiverStatus).IsRequired();
                entity.Property(e => e.CustomerStatus).IsRequired();
                entity.Property(e => e.IsAllFinish).IsRequired();
                entity.Property(e => e.TotalPrice).HasColumnType("money").HasConversion<double>().IsRequired();
                entity.Property(e => e.PurchasedTime).IsRequired();
                entity.Property(e => e.Status).HasMaxLength(32).IsRequired();
                entity.Property(e => e.Queue).IsRequired();

                entity.HasOne(e => e.Receiver).WithMany(e => e.PurchasedOrders).HasForeignKey(e => e.ReceiverId);
                entity.Property(e => e.ReceiverId).HasMaxLength(64);

                entity.HasOne(e => e.Customer).WithMany(e => e.PurchasedOrders).HasForeignKey(e => e.CustomerId).IsRequired();
                entity.Property(e => e.CustomerId).HasMaxLength(4).IsRequired();

                entity.HasMany(e => e.PurchasedMenus).WithOne(e => e.PurchasedOrder).HasForeignKey(e => e.PurchasedOrderId).IsRequired();
            });
            builder.Entity<Basket>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Customer).WithOne(e => e.Basket).IsRequired();
                entity.HasMany(e => e.PurchasedMenus).WithOne(e => e.Basket).HasForeignKey(e => e.BasketId).IsRequired();
                entity.HasMany(e => e.SelectedMenus).WithOne(e => e.Basket).HasForeignKey(e => e.BasketId).IsRequired();

            });
            builder.Entity<PurchasedMenu>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Note).HasMaxLength(512).IsRequired();
                entity.Property(e=> e.IsFinish).IsRequired();
                entity.Property(e => e.CookId).HasMaxLength(64);

                entity.HasOne(e => e.PurchasedOrder).WithMany(e => e.PurchasedMenus).HasForeignKey(e => e.PurchasedOrderId).IsRequired();
                entity.HasOne(e => e.Basket).WithMany(e => e.PurchasedMenus).HasForeignKey(e => e.BasketId).IsRequired();
                entity.HasOne(e => e.Menu).WithMany(e => e.PurchasedMenus).HasForeignKey(e => e.MenuNameId).IsRequired();
                entity.HasOne(e => e.Cook).WithMany(e => e.PurchasedMenu).HasForeignKey(e => e.CookId);

                entity.HasMany(e => e.MenusStatus).WithOne(e => e.PurchasedMenu).HasForeignKey(e => e.PurchasedMenuId).IsRequired();
            });
            builder.Entity<Cook>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e=>e.DepartmentId).HasMaxLength(64).IsRequired();
                entity.Property(e => e.PositionId).HasMaxLength(64).IsRequired();
                entity.Property(e => e.EmployeeId).HasMaxLength(64).IsRequired();
                entity.HasOne(e => e.Position).WithMany(e => e.Cooks).HasForeignKey(e => e.PositionId).IsRequired();
                entity.HasOne(e => e.Department).WithMany(e => e.Cooks).HasForeignKey(e => e.DepartmentId).IsRequired();
                entity.HasOne(e => e.Employee).WithMany(e => e.Cooks).HasForeignKey(e => e.EmployeeId).IsRequired();
            });
            builder.Entity<Receiver>(entity => 
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
            builder.Entity<Department>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Cooks).WithOne(e => e.Department).HasForeignKey(e => e.DepartmentId).IsRequired();
                entity.HasMany(e => e.Receivers).WithOne(e => e.Department).HasForeignKey(e => e.DepartmentId).IsRequired();
            });
            builder.Entity<Position>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e =>e.Salary).IsRequired();
                entity.Property(e => e.WorkingTimeIn).IsRequired();
                entity.Property(e => e.WorkingTimeOut).IsRequired();
                entity.HasMany(e => e.Cooks).WithOne(e => e.Position).HasForeignKey(e => e.PositionId).IsRequired();
                entity.HasMany(e => e.Receivers).WithOne(e => e.Position).HasForeignKey(e => e.PositionId).IsRequired();
            });
            builder.Entity<MenusStatus>(entity => 
            {
                entity.HasKey(e=>e.Id);
                entity.Property(e => e.IsFinish).IsRequired();
                entity.HasOne(e => e.PurchasedMenu).WithMany(e => e.MenusStatus).HasForeignKey(e => e.PurchasedMenuId).IsRequired();
            });
            builder.Entity<AGVStatus>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CodeName).HasMaxLength(4).IsRequired();
                entity.Property(e => e.Battery);
                entity.Property(e => e.IsAvaliable).IsRequired();
            });
            builder.Entity<SelectedMenu>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Note).HasMaxLength(512);

                entity.HasOne(e => e.Basket).WithMany(e => e.SelectedMenus).HasForeignKey(e=>e.BasketId).IsRequired();
                entity.HasOne(e => e.Menu).WithMany(e => e.SelectedMenus).HasForeignKey(e => e.MenuId).IsRequired();
            });
            builder.Entity<BillOrder>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.BillingTime);
                entity.Property(e => e.CountingOrder);
                entity.Property(e => e.OrderPrice).HasColumnType("money").HasConversion<double>();
                entity.Property(e => e.VatPrice).HasColumnType("money").HasConversion<double>();
                entity.Property(e => e.Discount).HasColumnType("money").HasConversion<double>();
                entity.Property(e => e.TotalPrice).HasColumnType("money").HasConversion<double>();
                entity.Property(e => e.BillingSlipUri);

                entity.Property(e => e.CustomerId).HasMaxLength(4);
                entity.HasOne(e => e.Customer).WithOne(e => e.BillOrder).IsRequired();

            });
    }

}