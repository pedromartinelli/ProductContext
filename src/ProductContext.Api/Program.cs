using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using ProductContext.Api;
using ProductContext.Api.Auth;
using ProductContext.Application.Interfaces;
using ProductContext.Application.Services;
using ProductContext.Domain.Interfaces;
using ProductContext.Domain.Interfaces.Repositories;
using ProductContext.Infra.Data;
using ProductContext.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Product API",
        Description = "Uma ASP.NET Core Web API para gerenciamento de produtos.",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {{
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }}
    );
});

LoadConfiguration(builder);
ConfigureApi(builder);
ConfigureAuthentication(builder);
ConfigureDbContext(builder);
ConfigureServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IProductService, ProductService>();
    services.AddScoped<IProductRepository, ProductRepository>();

    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IUserRepository, UserRepository>();

    services.AddScoped<ISessionService, SessionService>();

    services.AddScoped<IPasswordHashService, PasswordHashService>();
    services.AddScoped<TokenService>();
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

    builder.Services.AddDbContext<ProductDbContext>(options =>
        options.UseNpgsql(connectionString));
}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //            .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

    //builder.Services.AddAuthorization(config =>
    //{
    //    config.AddPolicy("AuthZPolicy", policyBuilder =>
    //        policyBuilder.Requirements.Add(new ScopeAuthorizationRequirement()));
    //});

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(options =>
    {
        builder.Configuration.Bind("AzureAd", options);
        options.TokenValidationParameters.RoleClaimType = "roles";
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.ClockSkew = TimeSpan.FromHours(10);
    }, options => builder.Configuration.Bind("AzureAd", options));
}

void LoadConfiguration(WebApplicationBuilder builder)
{
    var configuration = builder.Configuration;

    Configuration.JwtKey = configuration.GetValue<string>("JwtKey") ?? throw new InvalidOperationException("JwtKey não foi configurada corretamente.");
}