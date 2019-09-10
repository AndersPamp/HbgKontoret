using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;

namespace HbgKontoret.Data.Services
{
  public class ProfileService : IProfileService
  {
    private readonly IProfileRepository _profileRepository;

    public ProfileService(IProfileRepository profileRepository)
    {
      _profileRepository = profileRepository;
    }
    public async Task<IEnumerable<ProfileDto>> GetAllProfileAsync()
    {
      var profiles = await _profileRepository.GetAllProfilesAsync();
      return profiles;
    }
    public async Task<ProfileDto> GetProfileByIdAsync(Guid profileId)
    {
      var profile = await _profileRepository.GetProfileByIdAsync(profileId);
      if (profile != null)
      {
        return profile;
      }

      return null;
    }
    public async Task<ProfileDto> AddProfileAsync(string manager, string imageUrl, string linkedinUrl, string phoneNumber, string aboutMe)
    {
      var newProfileDto = new ProfileDto()
      {
        Manager = manager,
        ImageUrl = imageUrl,
        LinkedInUrl = linkedinUrl,
        PhoneNo = phoneNumber,
        AboutMe = aboutMe
      };
      if (await _profileRepository.AddProfileAsync(newProfileDto) != null)
      {
        return newProfileDto;
      }

      return null;
    }
    public async Task<ProfileDto> EditProfileAsync(Guid profileId, ProfileDto profileDto)
    {
      var profileForEdit = await _profileRepository.GetProfileByIdAsync(profileId);
      profileForEdit.Manager = profileDto.Manager;
      profileForEdit.ImageUrl = profileDto.ImageUrl;
      profileForEdit.LinkedInUrl = profileDto.LinkedInUrl;
      profileForEdit.PhoneNo = profileDto.PhoneNo;
      profileForEdit.AboutMe = profileDto.AboutMe;

      await _profileRepository.UpdateUserByIdAsync(profileId, profileForEdit);
      return profileForEdit;
    }
    public async Task<bool> DeleteProfileAsync(Guid profileId)
    {
      var profileForDeletion = await _profileRepository.GetProfileByIdAsync(profileId);

      if (profileForDeletion != null)
      {
        await _profileRepository.DeleteProfileByIdAsync(profileId);
        return true;
      }

      return false;
    }
  }
}


