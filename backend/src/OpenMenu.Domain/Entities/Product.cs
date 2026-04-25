using OpenMenu.Domain.Common;

namespace OpenMenu.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsAvailable { get; set; } = true;
    public int DisplayOrder { get; set; }

    // JSONB alanı — Task 1.4'te EF konfigürasyonu yapılacak
    public Dictionary<string, object>? Extras { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
