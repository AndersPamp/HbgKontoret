using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HbgKontoret.Data.Data.Repositories;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;
using Profile = HbgKontoret.Data.Entities.Profile;

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
      return profile;
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
      await _profileRepository.AddProfileAsync(newProfileDto);

      return newProfileDto;
    }


    public async Task<ProfileDto> EditProfileAsync(Guid profileId, string manager, string imageUrl, string linkedinUrl, string phoneNumber,
      string aboutMe)
    {
      var profileForEdit = await _profileRepository.GetProfileByIdAsync(profileId);
      profileForEdit.Manager = manager;
      profileForEdit.ImageUrl = imageUrl;
      profileForEdit.LinkedInUrl = linkedinUrl;
      profileForEdit.PhoneNo = phoneNumber;
      profileForEdit.AboutMe = aboutMe;

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


