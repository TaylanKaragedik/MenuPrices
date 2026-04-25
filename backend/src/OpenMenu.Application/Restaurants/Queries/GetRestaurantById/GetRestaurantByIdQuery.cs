using MediatR;
using OpenMenu.Application.Common;

namespace OpenMenu.Application.Restaurants.Queries.GetRestaurantById;

public record GetRestaurantByIdQuery(Guid Id) : IRequest<Result<RestaurantDto>>;
