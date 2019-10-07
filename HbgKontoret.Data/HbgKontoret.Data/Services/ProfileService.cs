using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
      try
      {
        var profiles = await _profileRepository.GetAllProfilesAsync();
        return profiles;
      }
      catch (Exception e)
      {
        throw new Exception(message:e.Message);
      }
    }
    public async Task<ProfileDto> GetProfileByIdAsync(Guid profileId)
    {
      try
      {
        var profile = await _profileRepository.GetProfileByIdAsync(profileId);
        if (profile != null)
        {
          return profile;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

      return null;
    }
    public async Task<ProfileDto> AddProfileAsync(string firstName, string lastName, string manager, string imageUrl, string linkedinUrl, string phoneNumber, string aboutMe)
    {
      try
      {
        var newProfileDto = new ProfileDto()
        {
          FirstName = firstName,
          LastName = lastName,
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
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

      return null;
    }
    public async Task<ProfileDto> EditProfileAsync(Guid profileId, ProfileDto profileDto)
    {
      try
      {
        var profileForEdit = await _profileRepository.GetProfileByIdAsync(profileId);
        profileForEdit.FirstName = profileDto.FirstName;
        profileForEdit.LastName = profileDto.LastName;
        profileForEdit.Manager = profileDto.Manager;
        profileForEdit.ImageUrl = profileDto.ImageUrl;
        profileForEdit.LinkedInUrl = profileDto.LinkedInUrl;
        profileForEdit.PhoneNo = profileDto.PhoneNo;
        profileForEdit.AboutMe = profileDto.AboutMe;

        await _profileRepository.UpdateProfileByIdAsync(profileId, profileForEdit);
        return profileForEdit;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    public async Task<bool> DeleteProfileAsync(Guid profileId)
    {
      try
      {
        var profileForDeletion = await _profileRepository.GetProfileByIdAsync(profileId);

        if (profileForDeletion != null)
        {
          await _profileRepository.DeleteProfileByIdAsync(profileId);
          return true;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

      return false;
    }
  }
}