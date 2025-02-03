using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportShop.Application.Commands.Products.Handlers;
using SportShop.Application.Queries.Products.Handlers;
using SportShop.Core.Entities;

namespace SportShop.Api.Controllers;

[Route("product")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator) 
        => _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult> CreateProduct(CreateProductCommand command, CancellationToken token)
    {
        await _mediator.Send(command, token);
        return NoContent();
    }

    [HttpGet("/products")]
    public async Task<IEnumerable<Product>> GetProducts(GetProductsQuery query, CancellationToken token)
        => await _mediator.Send(query, token);

    [HttpGet("{productId:guid}")]
    public async Task<Product> GetProduct(Guid ProductId, GetProductQuery query, CancellationToken token)
    {
        var product = await _mediator.Send(new GetProductQuery(ProductId), token);
        return product;
    } 
}