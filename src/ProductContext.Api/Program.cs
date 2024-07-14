using Microsoft.EntityFrameworkCore;
using ProductContext.Application.Interfaces;
using ProductContext.Application.Services;
using ProductContext.Domain.Interfaces;
using ProductContext.Infra.Data;
using ProductContext.Infra.Data.Mocks;
using ProductContext.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureApi(builder);
ConfigureDbContext(builder);
ConfigureServices(builder.Services);

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

void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IProductService, ProductService>();
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddSingleton<ProductsMock>();
}

void ConfigureApi(WebApplicationBuilder builder)
{
    builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
}

void ConfigureDbContext(WebApplicationBuilder builder) 
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(connectionString));
}