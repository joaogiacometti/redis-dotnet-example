using Application.Products.Commands.Create;
using Application.Products.Queries.GetAll;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetAllProductsUseCase>();
        services.AddScoped<CreateProductUseCase>();
    }
}