using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportShop.Application.Commands.Products.Handlers;

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
}