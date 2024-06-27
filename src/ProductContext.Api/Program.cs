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
ConfigureServices(builder);

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

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<ProductDbContext>();

    builder.Services.AddScoped<IProductService, ProductService>();

    builder.Services.AddScoped<IProductRepository, ProductRepository>();

    builder.Services.AddSingleton<ProductsMock>();
}

void ConfigureApi(WebApplicationBuilder builder)
{
    builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
}