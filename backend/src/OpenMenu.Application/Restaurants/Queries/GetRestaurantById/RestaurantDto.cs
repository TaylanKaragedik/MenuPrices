namespace OpenMenu.Application.Restaurants.Queries.GetRestaurantById;

public record RestaurantDto(
    Guid Id,
    string Name,
    string? Description,
    string? LogoUrl,
    string? Address,
    string? Phone,
    DateTime CreatedAt
);
