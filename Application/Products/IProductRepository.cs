using Domain.Entities;

namespace Application.Products;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(Product product, CancellationToken cancellationToken);
}