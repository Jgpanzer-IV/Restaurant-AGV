using RestaurantAGV.MVC.Constants;
using Microsoft.EntityFrameworkCore;
using RestaurantAGV.MVC.Database;
using RestaurantAGV.MVC.Services.Classes;
using RestaurantAGV.MVC.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RestaurantDbContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("RestaurantDataStore")));
var optionDbBuilder = new DbContextOptionsBuilder<RestaurantDbContext>();
optionDbBuilder.UseSqlite(builder.Configuration.GetConnectionString("RestaurantDataStore"));

ISubscriberMQTT subscriberMqttService = new SubscriberMQTT(optionDbBuilder.Options);
builder.Services.AddSingleton<ISubscriberMQTT>(subscriberMqttService);
await subscriberMqttService.InitialConnectAsync("broker.hivemq.com",1883);
await subscriberMqttService.ConnectToTopicAsync("RestaurantAGV/");

IPublisherMQTT publisherMqttService = new PublisherMQTT(optionDbBuilder.Options);
builder.Services.AddSingleton<IPublisherMQTT>(publisherMqttService);
await publisherMqttService.InitialConnectAsync("broker.hivemq.com",1883);
await publisherMqttService.PublishAsync("myTopic","This message sent from Web MVC.");


builder.Services.AddScoped<IMenuRepository,MenuRepository>();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<ITableRepository,TableRepository>();
builder.Services.AddScoped<IMenuCategoryRepository,MenuCategortRepository>();
builder.Services.AddScoped<IBasketRepository,BasketRepository>();
builder.Services.AddScoped<IBillingOrderRepository,BillingOrderRepository>();
builder.Services.AddScoped<IPurchasedMenuRepository,PurchasedMenuRepository>();
builder.Services.AddScoped<IPurchasedOrderRepository,PurchasedOrderRepository>();
builder.Services.AddScoped<ISelectedMenuRepository,SelectedMenuRepository>();





builder.Services.AddAuthentication(AuthConstants.DefaultScheme).AddCookie(AuthConstants.CookieScheme,config => {
    config.Cookie.Name = AuthConstants.Cookie;
    config.AccessDeniedPath = new PathString("/Auth/Forbidden");
    config.LoginPath = new PathString("/Auth/CustomerSignin");
    config.LogoutPath = new PathString("/Auth/CustomerSignout");
    config.ExpireTimeSpan = TimeSpan.FromDays(1);
});


builder.Services.AddAuthorization(config => {
    config.AddPolicy(AuthConstants.AdminPolicy, policy => {
        policy.RequireClaim("roles",RoleConst.StuffRole,RoleConst.AdminRole);
    });
    config.AddPolicy(AuthConstants.CustomerPolicy, policy => {
        policy.RequireClaim("roles",RoleConst.CustomerRole);
    });
});










var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
