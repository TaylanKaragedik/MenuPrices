using MediatR;
using OpenMenu.Application.Common;
using OpenMenu.Application.Restaurants.Queries.GetRestaurantById;

namespace OpenMenu.Application.Restaurants.Queries.GetAllRestaurants;

public record GetAllRestaurantsQuery : IRequest<Result<List<RestaurantDto>>>;
