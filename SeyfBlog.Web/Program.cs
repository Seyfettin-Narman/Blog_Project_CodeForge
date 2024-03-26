using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NToastNotify;
using SeyfBlog.Data.Context;
using SeyfBlog.Data.Extensions;
using SeyfBlog.Entity.Entities;
using SeyfBlog.Service.Extensions;
using SeyfBlog.Service.IdentityTurkishError;

var builder = WebApplication.CreateBuilder(args);
builder.Services.LoadDataExtensions(builder.Configuration);
builder.Services.LoadServiceExtension();
builder.Services.AddSession();
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddNToastNotifyToastr(
    new NToastNotify.ToastrOptions()
    {
        PositionClass = ToastPositions.BottomRight,
        TimeOut = 4000,
        ProgressBar = true
    });
builder.Services.AddDbContext<SeyfBlogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdUser, IdRole>(options =>
{
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
}).AddRoleManager<RoleManager<IdRole>>()
    .AddErrorDescriber<IdentityErrorDescriberTr>()
  .AddEntityFrameworkStores<SeyfBlogDbContext>()
  .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        Name = "SeyfBlogUygulamasi",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest 
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7);
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
      name: "Admin",
      areaName: "Admin",
      pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
     );
    endpoints.MapDefaultControllerRoute();
});

app.Run();
