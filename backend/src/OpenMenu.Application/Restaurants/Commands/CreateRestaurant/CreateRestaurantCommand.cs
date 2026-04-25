using MediatR;
using OpenMenu.Application.Common;

namespace OpenMenu.Application.Restaurants.Commands.CreateRestaurant;

public record CreateRestaurantCommand(
    string Name,
    string? Description,
    string? LogoUrl,
    string? Address,
    string? Phone
) : IRequest<Result<Guid>>;
