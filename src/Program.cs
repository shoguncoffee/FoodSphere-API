using Microsoft.EntityFrameworkCore;
using FoodSphere.Models;
using FoodSphere.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<FoodService>();
builder.Services.AddScoped<IngredientInfoService>();
builder.Services.AddScoped<IngredientStockService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<SubOrderService>();
builder.Services.AddScoped<RestaurantService>();
builder.Services.AddScoped<BranchService>();
builder.Services.AddScoped<TableService>();
builder.Services.AddScoped<WaiterService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FoodSphereContext>(opt =>
    opt.UseInMemoryDatabase("FoodSphere"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();