using System.Collections.Generic;
using System.Threading.Tasks;
using HbgKontoret.Infrastructure.Dto;

namespace HbgKontoret.Infrastructure.Interfaces
{
  public interface IOfficeRepository
  {
    Task<IEnumerable<OfficeDto>> GetAllOfficesAsync();
    Task<OfficeDto> GetOfficeByIdAsync(int id);
    Task<OfficeDto> AddOfficeAsync(OfficeDto officeDto);
    Task<OfficeDto> EditOfficeAsync(int id, OfficeDto officeDto);
    Task<bool> DeleteOfficeAsync(int id);
  }
}