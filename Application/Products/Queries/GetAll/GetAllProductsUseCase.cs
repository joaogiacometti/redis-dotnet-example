using Application.Cache;

namespace Application.Products.Queries.GetAll;

public class GetAllProductsUseCase(IProductRepository repository, ICacheService cacheService)
{
    public async Task<List<ResponseProductGetAll>> ExecuteAsync(bool useCache, CancellationToken cancellationToken)
    {
        if (useCache)
        {
            var cached = await cacheService.GetAsync<List<ResponseProductGetAll>>(CacheConstants.Products.All);
            if (cached != null)
                return cached;
        }
        
        var items = await repository.GetAllAsync(cancellationToken);
        var response = items
            .Select(p => new ResponseProductGetAll(
                p.Id,
                p.Name,
                p.Description))
            .ToList();

        if (useCache)
            await cacheService.SetAsync(CacheConstants.Products.All, response, CacheConstants.Products.AllExpiration);

        return response;
    }
}