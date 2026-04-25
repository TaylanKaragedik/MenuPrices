using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenMenu.Application.Common;
using OpenMenu.Application.Common.Interfaces;
using OpenMenu.Application.Restaurants.Queries.GetRestaurantById;

namespace OpenMenu.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler(IApplicationDbContext db)
    : IRequestHandler<GetAllRestaurantsQuery, Result<List<RestaurantDto>>>
{
    public async Task<Result<List<RestaurantDto>>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        var restaurants = await db.Restaurants
            .AsNoTracking()
            .OrderBy(r => r.Name)
            .Select(r => new RestaurantDto(
                r.Id,
                r.Name,
                r.Description,
                r.LogoUrl,
                r.Address,
                r.Phone,
                r.CreatedAt))
            .ToListAsync(cancellationToken);

        return Result<List<RestaurantDto>>.Success(restaurants);
    }
}
