using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using Microsoft.AspNetCore.Identity;
using WebApplication2.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebAppContextConnection") ?? throw new InvalidOperationException("Connection string 'WebAppContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

builder.Services.AddDbContext<MvcDBContext>(options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("MvcConnectionString")));

builder.Services.AddDbContext<WebAppContext>(options =>
    options.UseSqlServer(connectionString)); //updated    

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<WebAppContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
