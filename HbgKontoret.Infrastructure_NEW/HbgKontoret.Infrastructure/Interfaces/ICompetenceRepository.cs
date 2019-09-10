using System.Collections.Generic;
using System.Threading.Tasks;
using HbgKontoret.Infrastructure.Dto;

namespace HbgKontoret.Infrastructure.Interfaces
{
  public interface ICompetenceRepository
  {
    Task<IEnumerable<CompetenceDto>> GetAllCompetencesAsync();
    Task<CompetenceDto> GetCompetenceByIdAsync(int id);
    Task<CompetenceDto> AddCompetenceAsync(CompetenceDto competenceDto);
    Task<CompetenceDto> EditCompetenceAsync(int id, CompetenceDto competenceDto);
    Task<bool> DeleteCompetenceAsync(int id);
  }
}
