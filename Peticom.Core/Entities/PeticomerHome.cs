namespace Core.Entities;

public class PeticomerHome : BaseEntity
{
    public string UserId { get; set; }
    public string Type { get; set; }
    public bool Garden { get; set; }
    public bool Cigaret { get; set; }
    public bool Kid { get; set; }
}
