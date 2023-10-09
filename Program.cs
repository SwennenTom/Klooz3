using Klooz3.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;
using SendGrid.Helpers.Mail;
using Klooz3.Email;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add Identity with the desired settings
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Configure Identity options here
    options.SignIn.RequireConfirmedAccount = false; // Set to true or false as needed
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add SendGrid service
builder.Services.AddTransient<EmailService>();

// Configure SendGrid settings from appsettings.json
var emailSettings = builder.Configuration.GetSection("EmailSettings");
var smtpServer = emailSettings["SmtpServer"];
var port = int.Parse(emailSettings["Port"]);
var userName = emailSettings["UserName"];
var password = emailSettings["Password"];

builder.Services.Configure<EmailSettings>(options =>
{
    options.SmtpServer = smtpServer;
    options.Port = port;
    options.UserName = userName;
    options.Password = password;
});

var app = builder.Build();

SeedData.Seed(app);
await SeedData.EnsurePopulatedAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
