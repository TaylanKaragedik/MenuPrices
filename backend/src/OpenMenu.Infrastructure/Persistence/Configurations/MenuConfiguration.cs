using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenMenu.Domain.Entities;

namespace OpenMenu.Infrastructure.Persistence.Configurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasMany(m => m.Categories)
            .WithOne(c => c.Menu)
            .HasForeignKey(c => c.MenuId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
