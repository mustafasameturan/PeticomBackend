using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Peticom.Core.Entities;

public class Reservation : BaseEntity
{
    public string UserId { get; set; }
    public string PeticomerId { get; set; }
    public Guid AdId { get; set; }
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
    public int TotalPrice { get; set; }
    public string Description { get; set; }

    public UserApp UserApp { get; set; }
    public Ad Ad { get; set; }
}