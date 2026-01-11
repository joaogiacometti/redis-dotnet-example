using Application.Products.Commands.Create;
using Application.Products.Queries.GetAll;
using Application.Products.Queries.GetById;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetAllProductsUseCase>();
        services.AddScoped<GetProductByIdUseCase>();
        services.AddScoped<CreateProductUseCase>();
    }
}