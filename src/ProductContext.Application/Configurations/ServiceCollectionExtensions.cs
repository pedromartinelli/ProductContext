//using ProductContext.Application.Interfaces;
//using ProductContext.Application.Services;
//using ProductContext.Domain.Interfaces;
//using ProductContext.Infra.Data.Repositories;

//namespace ProductContext.Application.Configurations
//{
//    public static class ServiceCollectionExtensions
//    {
//        public static void AddApplicationServices(this IServiceCollection services)
//        {
//            // Registrar os serviços de aplicação
//            services.AddScoped<IProductService, ProductService>();

//            // Registrar os repositórios e outras dependências da infraestrutura
//            services.AddScoped<IProductRepository, ProductRepository>();

//            // Adicionar outros serviços e configurações
//        }
//    }
//}
