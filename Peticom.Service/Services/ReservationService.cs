using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Peticom.Core.Domain;
using Peticom.Core.Entities;
using Peticom.Core.Models.Reservation;
using Peticom.Core.Repositories;
using Peticom.Core.Responses;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;
using Peticom.Service.Exceptions;

namespace Peticom.Service.Services;

public class ReservationService : GenericService<Reservation, ReservationModel>, IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private IGenericRepository<Reservation> _repository;
    private readonly UserManager<UserApp> _userManager;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;

    public ReservationService(IUnitOfWork unitOfWork, IGenericRepository<Reservation> repository, IMapper mapper, IReservationRepository reservationRepository,
        UserManager<UserApp> userManager, IEmailService emailService, IConfiguration configuration) : base(unitOfWork, repository, mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
        _emailService = emailService;
    }

    public async Task<Response<List<ReservationModel>>> GetReservationsByAdId(Guid adId)
    {
        var reservations = await _reservationRepository.Where(r => r.AdId == adId).ToListAsync();

        if (reservations.Count == 0)
        {
            throw new NotFoundException("Pet identity not found.");
        }
        
        var reservationModels = _mapper.Map<List<ReservationModel>>(reservations);
        
        return Response<List<ReservationModel>>.Success(reservationModels, 200);
    }

    public async Task<Response<ReservationModel>> CreateReservation(ReservationModel reservationModel)
    {
        var createUser = await _userManager.FindByIdAsync(reservationModel.UserId);
        var peticomer = await _userManager.FindByIdAsync(reservationModel.PeticomerId);
        
        if (createUser == null)
        {
            return Response<ReservationModel>.Fail("User not found!", 404, true);
        }
        
        if (peticomer == null)
        {
            return Response<ReservationModel>.Fail("Peticomer not found!", 404, true);
        }
        
        var newEntity = _mapper.Map<Reservation>(reservationModel);
        await _repository.AddAsync(newEntity);
        await _unitOfWork.CommitAsync();
            
        //Send mail to create user
        _emailService.SendEmail(
            _configuration[Settings.SenderEmail], 
            createUser.Email, 
            "İlan Rezervasyonu Hakkında", 
            "Rezervasyonunuz başarıyla alınmıştır! Peticomer sizinle iletişime geçecek!"
        );
        
        _emailService.SendEmail(
            _configuration[Settings.SenderEmail], 
            peticomer.Email, 
            "İlanınız Hakkında", 
            "İlanınıza başvuru yapıldı! Kullanıcı numarası üzerinden iletişime geçebilirsiniz.\n Kullanıcı Ad/Soyad, Telefon Numarası ve E-Posta Adresi:" 
                + createUser.FullName + " / " + createUser.PhoneNumber + " / " + createUser.Email
        );
        
        var newModel = _mapper.Map<ReservationModel>(newEntity);

        return Response<ReservationModel>.Success(newModel, 200);  
        
    }
}