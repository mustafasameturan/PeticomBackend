namespace Peticom.Core.Entities;

public class PeticomerApplication : BaseEntity
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string? Description { get; set; }
    public bool? Status { get; set; }
    public bool? RejectStatus { get; set; }
}