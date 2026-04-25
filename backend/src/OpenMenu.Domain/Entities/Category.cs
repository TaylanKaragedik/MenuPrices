using OpenMenu.Domain.Common;

namespace OpenMenu.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }

    public Guid MenuId { get; set; }
    public Menu Menu { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = [];
}
