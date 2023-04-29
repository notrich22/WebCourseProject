using WebCourseProject_Vasilyev.Controllers;
using WebCourseProject_Vasilyev.LogicServices;
using WebCourseProject_Vasilyev.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebCourseProject_Vasilyev.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthContextConnection' not found.");

builder.Services.AddDbContext<AuthContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AuthContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<BuyersController>();
builder.Services.AddSingleton<BuyersLogicService>();
builder.Services.AddSingleton<ItemsController>();
builder.Services.AddSingleton<ItemsLogicService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
