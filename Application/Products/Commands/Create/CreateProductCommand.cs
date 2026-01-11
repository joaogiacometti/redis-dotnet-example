using Domain.Entities;

namespace Application.Products.Commands.Create;

public class CreateProductCommand(IProductRepository repository)
{
    public async Task<Guid> ExecuteAsync(RequestCreateProduct request, CancellationToken cancellationToken)
    {
        var newItem = new Product(name: request.Name, description: request.Description);

        await repository.CreateAsync(newItem, cancellationToken);

        return newItem.Id;
    }
}