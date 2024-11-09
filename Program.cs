using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;

var builder = WebApplication.CreateBuilder(args);

// The following highlighted code in Program.cs shows how to use SQLite in development and SQL Server in production.
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<MvcMovieContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("MvcMovieContext")));
}
else
{
    builder.Services.AddDbContext<MvcMovieContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMvcMovieContext")));
}

/*
builder.Services.AddDbContext<MvcMovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcMovieContext") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));
*/

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

/*
When you browse to the app and don't supply any URL segments, it defaults to the "Home" controller and the "Index" method specified in the template line below
The first URL segment determines the controller class to run. So localhost:5001/HelloWorld maps to the HelloWorld Controller class.
The second part of the URL segment determines the action method on the class.
So localhost:5001/HelloWorld/Index causes the Index method of the HelloWorldController class to run.
Notice that you only had to browse to localhost:5001/HelloWorld and the Index method was called by default.
Index is the default method that will be called on a controller if a method name isn't explicitly specified.
The third part of the URL segment ( id) is for route data. Route data is explained later in the tutorial. ...

In the following example:
-The third URL segment matched the route parameter id.
-The Welcome method contains a parameter id that matched the URL template in the MapControllerRoute method.
-The trailing ? (in id?) indicates the id parameter is optional.
*/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
