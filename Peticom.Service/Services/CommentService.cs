using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Models.Comment;
using Peticom.Core.Repositories;
using Peticom.Core.Responses;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;

namespace Peticom.Service.Services;

public class CommentService : GenericService<Comment, CommentModel>, ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly ISubCommentService _subCommentService;
    private readonly IMapper _mapper;
    
    public CommentService(IUnitOfWork unitOfWork, IGenericRepository<Comment> repository, IMapper mapper,
        ICommentRepository commentRepository, ISubCommentService subCommentService) : base(unitOfWork, repository, mapper)
    {
        _commentRepository = commentRepository;
        _subCommentService = subCommentService;
    }

    /// <summary>
    /// This method returns comments with sub comments.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Response<List<CommentWithSubCommentModel>>> GetCommentsWithSubCommentsAsync()
    {
        List<CommentWithSubCommentModel> commentWithSubCommentsModel = new List<CommentWithSubCommentModel>();
        var subComments = await _commentRepository.GetAll().ToListAsync();

        foreach (var comment in subComments)
        {
            var commentWithSubCommentModel = new CommentWithSubCommentModel
            {   
                Id = comment.Id,
                UserId = comment.UserId,
                Text = comment.Text,
                SubComments = await _subCommentService.GetSubCommentsByCommentIdAsync(comment.Id)
            };
            
            commentWithSubCommentsModel.Add(commentWithSubCommentModel);
        }

        return Response<List<CommentWithSubCommentModel>>.Success(commentWithSubCommentsModel, 200);
    }
}