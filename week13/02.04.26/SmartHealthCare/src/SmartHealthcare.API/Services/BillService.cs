using AutoMapper;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.API.Services.Interfaces;
using SmartHealthcare.Models.DTOs;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Services;

public class BillService : IBillService
{
    private readonly IBillRepository _repo;
    private readonly IMapper _mapper;
    private readonly ILogger<BillService> _logger;

    public BillService(IBillRepository repo, IMapper mapper, ILogger<BillService> logger)
    {
        _repo = repo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PagedResult<BillDTO>> GetAllAsync(int page, int pageSize)
    {
        var items = await _repo.GetAllWithDetailsAsync(page, pageSize);
        var total = await _repo.CountAsync();
        return new PagedResult<BillDTO>
        {
            Items = _mapper.Map<List<BillDTO>>(items),
            TotalCount = total,
            PageNumber = page,
            PageSize = pageSize
        };
    }

    public async Task<BillDTO?> GetByIdAsync(int id)
    {
        var bill = await _repo.GetWithDetailsAsync(id);
        return bill == null ? null : _mapper.Map<BillDTO>(bill);
    }

    public async Task<BillDTO?> GetByAppointmentIdAsync(int appointmentId)
    {
        var bill = await _repo.GetByAppointmentIdAsync(appointmentId);
        return bill == null ? null : _mapper.Map<BillDTO>(bill);
    }

    public async Task<PagedResult<BillDTO>> GetByPatientIdAsync(int patientId, int page, int pageSize)
    {
        var items = await _repo.GetByPatientIdAsync(patientId, page, pageSize);
        var total = await _repo.CountByPatientAsync(patientId);
        return new PagedResult<BillDTO>
        {
            Items = _mapper.Map<List<BillDTO>>(items),
            TotalCount = total,
            PageNumber = page,
            PageSize = pageSize
        };
    }

    public async Task<BillDTO> CreateAsync(CreateBillDTO dto)
    {
        var bill = _mapper.Map<Bill>(dto);
        bill.CreatedAt = DateTime.UtcNow;

        await _repo.AddAsync(bill);
        await _repo.SaveAsync();

        _logger.LogInformation("Bill created for AppointmentId={AppointmentId}, Total={Total}",
            dto.AppointmentId, bill.TotalAmount);

        var created = await _repo.GetWithDetailsAsync(bill.Id);
        return _mapper.Map<BillDTO>(created!);
    }

    public async Task<bool> UpdatePaymentStatusAsync(int id, UpdateBillPaymentDTO dto)
    {
        var bill = await _repo.GetByIdAsync(id);
        if (bill == null) return false;

        bill.PaymentStatus = dto.PaymentStatus;
        _repo.Update(bill);
        await _repo.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var bill = await _repo.GetByIdAsync(id);
        if (bill == null) return false;

        _repo.Delete(bill);
        await _repo.SaveAsync();
        return true;
    }
}