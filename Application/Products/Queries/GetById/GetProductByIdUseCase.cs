using Application.Cache;

namespace Application.Products.Queries.GetById;

public class GetProductByIdUseCase(IProductRepository repository, ICacheService cacheService)
{
    public async Task<ResponseProduct> ExecuteAsync(Guid id, bool useCache, CancellationToken cancellationToken)
    {
        if (useCache)
        {
            var cached = await cacheService.GetAsync<ResponseProduct>(CacheConstants.Products.ById(id));
            if (cached != null)
                return cached;
        }
        
        var item = await repository.GetByIdAsync(id, cancellationToken)
            ?? throw new KeyNotFoundException($"Product {id} not found");
        var response = new ResponseProduct(Id: item.Id, Name: item.Name, Description: item.Description);

        if (useCache)
            await cacheService.SetAsync(CacheConstants.Products.ById(id), response, CacheConstants.Products.ByIdExpiration);

        return response;
    }
}