using Application;
using Application.Products.Create;
using Application.Products.GetAll;
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

app.MapGet("/products", async ([FromServices] GetAllProductsQuery query, CancellationToken cancellationToken) =>
{
    var products = await query.ExecuteAsync(cancellationToken);
    
    return Results.Ok(products);
});

app.MapPost("/products", async 
    ([FromServices] CreateProductCommand command, [FromBody] RequestCreateProduct request, CancellationToken cancellationToken) =>
{
    var id = await command.ExecuteAsync(request, cancellationToken);
    
    return Results.Created($"/products/{id}", id);
});

app.Run();