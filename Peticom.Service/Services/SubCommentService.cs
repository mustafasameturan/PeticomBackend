using AutoMapper;
using Peticom.Core.Entities;
using Peticom.Core.Models.SubComment;
using Peticom.Core.Repositories;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;

namespace Peticom.Service.Services;

public class SubCommentService : GenericService<SubComment, SubCommentModel>, ISubCommentService
{
    private readonly ISubCommentRepository _subCommentRepository;
    private readonly IMapper _mapper;
    
    public SubCommentService(IUnitOfWork unitOfWork, IGenericRepository<SubComment> repository, IMapper mapper,
        ISubCommentRepository subCommentRepository) : base(unitOfWork, repository, mapper)
    {
        _subCommentRepository = subCommentRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// This method get sub comments for server.
    /// </summary>
    /// <param name="commentId"></param>
    /// <returns></returns>
    public async Task<List<SubCommentModel>> GetSubCommentsByCommentIdAsync(Guid commentId)
    {
        var subComments = await _subCommentRepository.GetSubCommentsByCommentId(commentId);
        
        var mappedSubComments = _mapper.Map<List<SubCommentModel>>(subComments);
        
        return mappedSubComments;
    }
}