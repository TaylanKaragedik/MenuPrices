using Microsoft.EntityFrameworkCore;
using OpenMenu.Domain.Entities;

namespace OpenMenu.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Restaurant> Restaurants { get; }
    DbSet<Menu> Menus { get; }
    DbSet<Category> Categories { get; }
    DbSet<Product> Products { get; }
    DbSet<QRRequest> QRRequests { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
