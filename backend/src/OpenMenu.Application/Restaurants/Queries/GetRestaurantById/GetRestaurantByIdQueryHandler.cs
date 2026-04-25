using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenMenu.Application.Common;
using OpenMenu.Application.Common.Interfaces;

namespace OpenMenu.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(IApplicationDbContext db)
    : IRequestHandler<GetRestaurantByIdQuery, Result<RestaurantDto>>
{
    public async Task<Result<RestaurantDto>> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await db.Restaurants
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (restaurant is null)
            return Result<RestaurantDto>.Failure("Restoran bulunamadı.");

        return Result<RestaurantDto>.Success(new RestaurantDto(
            restaurant.Id,
            restaurant.Name,
            restaurant.Description,
            restaurant.LogoUrl,
            restaurant.Address,
            restaurant.Phone,
            restaurant.CreatedAt));
    }
}
