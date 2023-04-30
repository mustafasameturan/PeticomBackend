namespace Core.Entities;

public class PeticomerBadge : BaseEntity
{
    public string UserId { get; set; }
    public bool Cigaret { get; set; }
    public bool Car { get; set; }
    public int CarDistance { get; set; }
    public bool Pet { get; set; }
    public bool Garden { get; set; }
}