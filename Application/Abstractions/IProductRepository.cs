using Domain.Entities;

namespace Application.Products;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken);
    Task CreateAsync(Product product, CancellationToken cancellationToken);
}