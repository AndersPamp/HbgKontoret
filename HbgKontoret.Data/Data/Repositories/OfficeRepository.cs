using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HbgKontoret.Data.Entities;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HbgKontoret.Data.Data.Repositories
{
  public class OfficeRepository:IOfficeRepository
  {
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;
    public OfficeRepository(AppDbContext appDbContext, IMapper mapper)
    {
      _appDbContext = appDbContext;
      _mapper = mapper;
    }

    public async Task<IEnumerable<OfficeDto>> GetAllOfficesAsync()
    {
      var offices = await _appDbContext.Offices.ToListAsync();
      if (offices!=null)
      {
        var officeDtos = _mapper.Map<IEnumerable<Office>,IEnumerable<OfficeDto>>(offices);
        return officeDtos;
      }

      return null;
    }

    public async Task<OfficeDto> GetOfficeByIdAsync(int id)
    {
      var office = await _appDbContext.Offices.FirstOrDefaultAsync(of=>of.Id==id);
      if (office!=null)
      {
        var officeDto = _mapper.Map<Office, OfficeDto>(office);

        return officeDto;
      }

      return null;
    }

    public async Task<OfficeDto> AddOfficeAsync(OfficeDto officeDto)
    {
      var office = _mapper.Map<OfficeDto, Office>(officeDto);
      await _appDbContext.Offices.AddAsync(office);
      await _appDbContext.SaveChangesAsync();
      var newOfficeDto = _mapper.Map<Office, OfficeDto>(office);

      if (newOfficeDto != null)
      {
        return newOfficeDto;
      }

      return null;
    }

    public async Task<OfficeDto> EditOfficeAsync(int id, OfficeDto officeDto)
    {
      var officeForEdit = await _appDbContext.Offices.FirstOrDefaultAsync(of => of.Id == id);
      if (officeForEdit!=null)
      {
        officeForEdit.Manager = officeDto.Manager;
        officeForEdit.Name = officeDto.Name;
        officeForEdit.Address = officeDto.Address;
        officeForEdit.Phone = officeDto.Phone;

        _appDbContext.Offices.Update(officeForEdit);

        var newOffice =  await _appDbContext.Offices.FirstOrDefaultAsync(od => od.Id == id);
        var newOfficeDto = _mapper.Map<Office, OfficeDto>(newOffice);
        return newOfficeDto;
      }

      return null;
    }

    public async Task<bool> DeleteOfficeAsync(int id)
    {
      var officeForDeletion = await _appDbContext.Offices.FirstOrDefaultAsync(of => of.Id == id);
      if (officeForDeletion!=null)
      {
        _appDbContext.Offices.Remove(officeForDeletion);
        await _appDbContext.SaveChangesAsync();
        return true;
      }

      return false;
    }
  }
}
