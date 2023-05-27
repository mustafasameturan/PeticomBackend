using Peticom.Core.Models.SubComment;

namespace Peticom.Core.Models.Comment;

public class CommentWithSubCommentModel
{
    public Guid? Id { get; set; }
    public string UserId { get; set; }
    public string Text { get; set; }
    public List<SubCommentModel> SubComments { get; set; }
}