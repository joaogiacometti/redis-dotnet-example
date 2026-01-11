namespace Application.Products.Queries.GetAll;

public class GetAllProductsQuery(IProductRepository repository)
{
    public async Task<IReadOnlyList<ResponseProductGetAll>> ExecuteAsync(CancellationToken cancellationToken)
    {
        var items = await repository.GetAllAsync(cancellationToken);

        return items
            .Select(p => new ResponseProductGetAll(
                p.Id,
                p.Name,
                p.Description))
            .ToList();
    }
}