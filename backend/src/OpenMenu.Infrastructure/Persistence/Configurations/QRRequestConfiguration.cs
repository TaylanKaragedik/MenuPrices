using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenMenu.Domain.Entities;

namespace OpenMenu.Infrastructure.Persistence.Configurations;

public class QRRequestConfiguration : IEntityTypeConfiguration<QRRequest>
{
    public void Configure(EntityTypeBuilder<QRRequest> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.ImagePath)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(q => q.DecodedUrl)
            .HasMaxLength(2000);

        builder.Property(q => q.ErrorMessage)
            .HasMaxLength(1000);

        builder.Property(q => q.Status)
            .HasConversion<string>();

        builder.HasOne(q => q.Restaurant)
            .WithMany()
            .HasForeignKey(q => q.RestaurantId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
