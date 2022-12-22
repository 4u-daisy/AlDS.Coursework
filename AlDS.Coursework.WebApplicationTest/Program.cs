using AlDS.Coursework.Board.UserModel;
using AlDS.Coursework.WebApplicationTest.Data;
using AlDS.Coursework.WebApplicationTest.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

// TODO добавление пользователей / drag and drop / 


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.GetSection(Config.Project).Bind(new Config());
var connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=ADS; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString),
    ServiceLifetime.Transient);

//builder.Services.AddTransient<ApplicationDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<User>(
    options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else 
{
    app.UseExceptionHandler("/Error");    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Person}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default", "{controller=Board}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default", "{controller=Note}/{action=Index}/{id?}");
});
app.MapRazorPages();
app.Run();
