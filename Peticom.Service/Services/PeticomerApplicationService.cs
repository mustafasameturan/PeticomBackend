using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Peticom.Core.Domain;
using Peticom.Core.Entities;
using Peticom.Core.Models;
using Peticom.Core.Models.PeticomerApplication;
using Peticom.Core.Repositories;
using Peticom.Core.Responses;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;

namespace Peticom.Service.Services;

public class PeticomerApplicationService : GenericService<PeticomerApplication, PeticomerApplicationModel>, IPeticomerApplicationService
{
    private readonly IPeticomerApplicationRepository _peticomerApplicationRepository;
    private readonly UserManager<UserApp> _userManager;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;
    
    public PeticomerApplicationService(IUnitOfWork unitOfWork, IGenericRepository<PeticomerApplication> repository, IMapper mapper,
        IPeticomerApplicationRepository peticomerApplicationRepository, IEmailService emailService, IConfiguration configuration,
        UserManager<UserApp> userManager) : base(unitOfWork, repository, mapper)
    {
        _peticomerApplicationRepository = peticomerApplicationRepository;
        _userManager = userManager;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _emailService = emailService;
        _configuration = configuration;
    }

    /// <summary>
    /// This method get peticomer application by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<Response<PeticomerApplicationWithStatusModel>> GetPeticomerApplicationByUserIdAsync(string userId)
    {
        var peticomerApplication = await _peticomerApplicationRepository.Where(p => p.UserId == userId).FirstOrDefaultAsync();

        if (peticomerApplication == null)
        {
            return Response<PeticomerApplicationWithStatusModel>.Fail("Peticomer application not found", 404, true);
        }

        var mappedPeticomerApplication = _mapper.Map<PeticomerApplicationWithStatusModel>(peticomerApplication);

        return Response<PeticomerApplicationWithStatusModel>.Success(mappedPeticomerApplication, 200);
    }

    /// <summary>
    /// This method get peticomer application by application id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Response<PeticomerApplicationWithStatusModel>> GetPeticomerApplicationByIdAsync(Guid id)
    {
        var peticomerApplication = await _peticomerApplicationRepository.Where(p => p.Id == id).FirstOrDefaultAsync();

        if (peticomerApplication == null)
        {
            return Response<PeticomerApplicationWithStatusModel>.Fail("Peticomer application not found", 404, true);
        }

        var mappedPeticomerApplication = _mapper.Map<PeticomerApplicationWithStatusModel>(peticomerApplication);
        
        return Response<PeticomerApplicationWithStatusModel>.Success(mappedPeticomerApplication, 200);
    }

    /// <summary>
    /// This method get all peticomer applications with status.
    /// </summary>
    /// <returns></returns>
    public async Task<Response<List<PeticomerApplicationWithStatusModel>>> GetAllPeticomerApplicationsAsync()
    {
        var peticomerApplications = await _peticomerApplicationRepository.GetAll().ToListAsync();

        var mappedPeticomerApplications = _mapper.Map<List<PeticomerApplicationWithStatusModel>>(peticomerApplications);

        return Response<List<PeticomerApplicationWithStatusModel>>.Success(mappedPeticomerApplications, 200);
    }

    /// <summary>
    /// This method used for create custom peticomer application.
    /// </summary>
    /// <param name="peticomerApplicationModel"></param>
    /// <returns></returns>
    public async Task<Response<PeticomerApplicationModel>> CreateApplication(PeticomerApplicationModel peticomerApplicationModel)
    {
        var peticomerApplication = _peticomerApplicationRepository
            .Where(p => p.UserId == peticomerApplicationModel.UserId).FirstOrDefault();

        var user = await _userManager.FindByIdAsync(peticomerApplicationModel.UserId);

        if (peticomerApplication != null)
        {
            return Response<PeticomerApplicationModel>.Fail("You have already applicaton!", 400, true);
        }

        if (!user.EmailConfirmed)
        {
            return Response<PeticomerApplicationModel>.Fail("You must verificate email!", 400, true);
        }
        
        var newApplication = _mapper.Map<PeticomerApplication>(peticomerApplicationModel);

        await _peticomerApplicationRepository.AddAsync(newApplication);

        await _unitOfWork.CommitAsync();

        var newModel = _mapper.Map<PeticomerApplicationModel>(newApplication);
            
        _emailService.SendEmail(_configuration[Settings.SenderEmail], peticomerApplicationModel.Email, "Başvuru Hakkında", 
            "Başvurunuz alınmıştır. En kısa süre içerisinde başvurunuza geri dönüş yapılacaktır.");

        return Response<PeticomerApplicationModel>.Success(newModel, 200);
    }

    /// <summary>
    /// This method used for approve peticomer application by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<Response<NoDataModel>> ApprovePeticomerApplicationByUserId(string userId)
    {
        var peticomerApplication = _peticomerApplicationRepository.Where(p => p.UserId == userId).FirstOrDefault();
        var user = await _userManager.FindByIdAsync(userId);

        if (peticomerApplication != null) 
        {
            peticomerApplication.Status = true;

            await _unitOfWork.CommitAsync();

            _emailService.SendEmail(_configuration[Settings.SenderEmail], peticomerApplication.Email, "Başvuru Onayı Hakkında",
                "Peticomer başvurunuz onaylanmıştır.\n Başvuru yaptığınız hesabınız üzerinden işlem yapabilirsiniz. Hesabınızdan çıkış yapıp tekrar giriş yapmanızı rica ederiz!");

            await _userManager.AddToRoleAsync(user, Roles.Peticomer);
            return Response<NoDataModel>.Success("Peticomer application was successfully approved." ,200);
        }
        
        return Response<NoDataModel>.Fail("Peticomer application not found.", 404, true);
    }

    /// <summary>
    /// This method used for reject peticomer application by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<Response<NoDataModel>> RejectPeticomerApplicationByUserId(string userId)
    {
        var peticomerApplication = _peticomerApplicationRepository.Where(p => p.UserId == userId).FirstOrDefault();

        if (peticomerApplication != null)
        {
            peticomerApplication.RejectStatus = false;

            await _unitOfWork.CommitAsync();
            
            _emailService.SendEmail(_configuration[Settings.SenderEmail], peticomerApplication.Email, "Başvuru Onayı Hakkında",
                "Başvurunuz onaylanmadı.");

            return Response<NoDataModel>.Success("Peticomer application successfully rejected.", 200);
        }
        
        return Response<NoDataModel>.Fail("Peticomer application not found.", 404, true);
    }
}