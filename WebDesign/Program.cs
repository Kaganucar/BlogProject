using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
using System.Web.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IRepositories<TBLBlog>, Repositories<TBLBlog>>();
builder.Services.AddScoped<IRepositories<TBLUser>, Repositories<TBLUser>>();
builder.Services.AddScoped<IRepositories<TBLCategories>, Repositories<TBLCategories>>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.LoginPath = "/Account/Login";
    opt.LoginPath = "/Account/Exit";
    opt.AccessDeniedPath = "/Admin/Unauthorized";
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

https://localhost:45/admin
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "Areas",
      pattern: "{area:exists}/{controller=Login}/{action=Index}/{Id?}"
    );

});

app.Run();
