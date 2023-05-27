namespace Peticom.Core.Entities;

public class Comment : BaseEntity
{
    public string UserId { get; set; }
    public string Text { get; set; }
    public ICollection<SubComment> SubComments { get; set; }
}