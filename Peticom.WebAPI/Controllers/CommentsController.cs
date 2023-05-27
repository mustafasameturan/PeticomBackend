using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Models.Comment;
using Peticom.Core.Services;

namespace Peticom.WebAPI.Controllers;

[Route("api/comments")]
[ApiController]
public class CommentsController : BaseController
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    
    /// <summary>
    /// This method is used to get all comments.
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _commentService.GetAllAsync());
    }
    
    /// <summary>
    /// This method is used to get comments with sub comments.
    /// </summary>
    /// <returns></returns>
    [HttpGet("getCommentsWithSubComments")]
    public async Task<IActionResult> GetCommentsWithSubComments()
    {
        return CreateActionResult(await _commentService.GetCommentsWithSubCommentsAsync());
    }
    
    /// <summary>
    /// This method is used to add sub comment.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("add")]
    public async Task<IActionResult> Add(CommentModel model)
    {
        return CreateActionResult(await _commentService.AddAsync(model));
    }
}