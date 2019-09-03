using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HbgKontoret.Data.Entities;
using HbgKontoret.Data.Entities.Dto;
using Microsoft.AspNetCore.JsonPatch;

namespace HbgKontoret.Data.Services.Interfaces
{
  public interface IProfileService
  {
    
    Task<Profile> AddProfileAsync(string manager, string imageUrl, string linkedinUrl, string phoneNumber, string aboutMe);
    Task<bool> DeleteProfileAsync(Guid profileId);
    Task<IEnumerable<ProfileDto>> GetAllProfileAsync();
    Task<Profile> GetProfileByIdAsync(Guid profileId);
    //Task<Profile> EditProfileAsync(Guid id, JsonPatchDocument<Profile> profile);


    Task<Profile> EditProfileAsync(Guid profileId, string manager, string imageUrl, string linkedinUrl, string phoneNumber, string aboutMe);
  }
}
