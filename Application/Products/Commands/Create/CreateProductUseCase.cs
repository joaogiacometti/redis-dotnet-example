using Application.Cache;
using Domain.Entities;

namespace Application.Products.Commands.Create;

public class CreateProductUseCase(IProductRepository repository, ICacheService cacheService)
{
    public async Task<Guid> ExecuteAsync(RequestCreateProduct request, CancellationToken cancellationToken)
    {
        var newItem = new Product(name: request.Name, description: request.Description);

        await repository.CreateAsync(newItem, cancellationToken);

        await cacheService.RemoveAsync(CacheConstants.Products.All);

        return newItem.Id;
    }
}