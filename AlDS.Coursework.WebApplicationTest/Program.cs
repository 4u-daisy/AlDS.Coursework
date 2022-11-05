using AlDS.Coursework.Board.UserModel;
using AlDS.Coursework.WebApplicationTest.Configuration;
using AlDS.Coursework.WebApplicationTest.Data;
using AlDS.Coursework.WebApplicationTest.Interfaces;
using AlDS.Coursework.WebApplicationTest.Services;
using AlDS.Coursework.WebApplicationTest.Services.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
var connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=TestProject_AlDStwo; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// TODO разобраться почему оно блин не работает((
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
builder.Services.AddTransient<IMailService, AlDS.Coursework.WebApplicationTest.Services.Email.MailService>();


builder.Services.AddRazorPages();

//builder.Services.Configure(builder.Configuration.GetSection(nameof(MailSettings)));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
});


app.MapRazorPages();

app.Run();
