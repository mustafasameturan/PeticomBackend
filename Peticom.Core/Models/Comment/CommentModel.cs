namespace Peticom.Core.Models.Comment;

public class CommentModel
{
    public Guid? Id { get; set; }
    public string UserId { get; set; }
    public string Text { get; set; }
}