using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HbgKontoret.Infrastructure.Dto;

namespace HbgKontoret.Infrastructure.Interfaces
{
  public interface IProfileRepository
  {
    Task<IEnumerable<ProfileDto>> GetAllProfilesAsync();
    Task<ProfileDto> GetProfileByIdAsync(Guid id);
    Task<ProfileDto> AddProfileAsync(ProfileDto profileDto);
    Task<ProfileDto> UpdateUserByIdAsync(Guid id, ProfileDto profileDto);
    Task<bool> DeleteProfileByIdAsync(Guid id);
    Task<IEnumerable<CompetenceDto>> GetCompetencesAsync(Guid profileId);
    Task<IEnumerable<CompetenceDto>> AddCompetenceAsync(Guid profileId, int competenceId);
  }
}
