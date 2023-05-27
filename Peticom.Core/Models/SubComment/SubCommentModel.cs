namespace Peticom.Core.Models.SubComment;

public class SubCommentModel
{
    public Guid? Id { get; set; }
    public string UserId { get; set; }
    public Guid CommentId { get; set; }
    public string Text { get; set; }
}