using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenMenu.Application.Restaurants.Commands.CreateRestaurant;
using OpenMenu.Application.Restaurants.Queries.GetAllRestaurants;
using OpenMenu.Application.Restaurants.Queries.GetRestaurantById;

namespace OpenMenu.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllRestaurantsQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetRestaurantByIdQuery(id), cancellationToken);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRestaurantCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
    }
}
