using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HbgKontoret.Infrastructure.Dto;

namespace HbgKontoret.Infrastructure.Interfaces
{
  public interface IProfileService
  {
    
    Task<ProfileDto> AddProfileAsync(string manager, string imageUrl, string linkedinUrl, string phoneNumber, string aboutMe);
    Task<bool> DeleteProfileAsync(Guid profileId);
    Task<IEnumerable<ProfileDto>> GetAllProfileAsync();
    Task<ProfileDto> GetProfileByIdAsync(Guid profileId);
    Task<ProfileDto> EditProfileAsync(Guid profileId, ProfileDto profileDto);
  }
}
