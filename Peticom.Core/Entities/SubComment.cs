namespace Peticom.Core.Entities;

public class SubComment : BaseEntity
{
    public string UserId { get; set; }
    public Guid CommentId { get; set; }
    public string Text { get; set; }
    public int LikeCount { get; set; }
    
    public Comment Comment { get; set; }
}