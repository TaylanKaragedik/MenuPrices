using MediatR;
using OpenMenu.Application.Common;
using OpenMenu.Application.Common.Interfaces;
using OpenMenu.Domain.Entities;

namespace OpenMenu.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(IApplicationDbContext db)
    : IRequestHandler<CreateRestaurantCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = new Restaurant
        {
            Name = request.Name,
            Description = request.Description,
            LogoUrl = request.LogoUrl,
            Address = request.Address,
            Phone = request.Phone
        };

        db.Restaurants.Add(restaurant);
        await db.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(restaurant.Id);
    }
}
