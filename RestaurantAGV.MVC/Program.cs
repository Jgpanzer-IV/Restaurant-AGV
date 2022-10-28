using RestaurantAGV.MVC.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


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
