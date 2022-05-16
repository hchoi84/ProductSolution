using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();
using var scope = app.Services.CreateScope();
var productDbContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();

  productDbContext.Database.EnsureDeleted();
  productDbContext.Database.EnsureCreated();
  productDbContext.Database.Migrate();
  productDbContext.Seed();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();