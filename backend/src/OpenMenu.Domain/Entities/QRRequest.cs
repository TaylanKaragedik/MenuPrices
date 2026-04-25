using OpenMenu.Domain.Common;
using OpenMenu.Domain.Enums;

namespace OpenMenu.Domain.Entities;

public class QRRequest : BaseEntity
{
    public string ImagePath { get; set; } = string.Empty;
    public string? DecodedUrl { get; set; }
    public QRRequestStatus Status { get; set; } = QRRequestStatus.Pending;
    public string? ErrorMessage { get; set; }

    public Guid? RestaurantId { get; set; }
    public Restaurant? Restaurant { get; set; }
}
