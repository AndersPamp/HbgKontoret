using System;
using System.Collections.Generic;
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
    Task<ProfileCompetenceDto> AddProfileCompetenceAsync(ProfileCompetenceDto profileCompetenceDto);
    Task<bool> DeleteProfileCompetenceAsync(ProfileCompetenceDto profileCompetenceDto);
    Task<ProfileOfficeDto> AddProfileOfficeAsync(ProfileOfficeDto profileOfficeDto);
    Task<bool> DeleteProfileOfficeAsync(ProfileOfficeDto profileOfficeDto);
  }
}
