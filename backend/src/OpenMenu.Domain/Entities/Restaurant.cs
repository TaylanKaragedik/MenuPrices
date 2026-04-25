using OpenMenu.Domain.Common;

namespace OpenMenu.Domain.Entities;

public class Restaurant : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }

    public ICollection<Menu> Menus { get; set; } = [];
}
