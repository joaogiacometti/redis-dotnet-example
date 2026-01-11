using Application;
using Application.Products.Commands.Create;
using Application.Products.Queries.GetAll;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    DotNetEnv.Env.Load(".env");
}

app.MapGet("/products", async (
    [FromServices] GetAllProductsUseCase useCase,
    CancellationToken cancellationToken,
    [FromQuery] bool useCache = true ) =>
{
    var products = await useCase.ExecuteAsync(useCache: useCache, cancellationToken);
    
    return Results.Ok(products);
});

app.MapPost("/products", async (
        [FromServices] CreateProductUseCase useCase, 
        [FromBody] RequestCreateProduct request, 
        CancellationToken cancellationToken) =>
{
    var id = await useCase.ExecuteAsync(request, cancellationToken);
    
    return Results.Created($"/products/{id}", id);
});

app.Run();