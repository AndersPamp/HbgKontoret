using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HbgKontoret.Data.Data.Repositories;
using HbgKontoret.Data.Entities.Dto;
using HbgKontoret.Data.Services.Interfaces;
using Profile = HbgKontoret.Data.Entities.Profile;

namespace HbgKontoret.Data.Services
{
  public class ProfileService : IProfileService
  {
    private readonly ProfileRepository _profileRepository;
    private readonly IMapper _mapper;

    public ProfileService(ProfileRepository profileRepository, IMapper mapper)
    {
      _profileRepository = profileRepository;
      _mapper = mapper;
    }
    public async Task<IEnumerable<ProfileDto>> GetAllProfileAsync()
    {
      var profiles = await _profileRepository.GetAllProfilesAsync();
      var prodileDtos = _mapper.Map<IEnumerable<Profile>, IEnumerable<ProfileDto>>(profiles);
      return prodileDtos;
    }
    public async Task<Profile> GetProfileByIdAsync(Guid profileId)
    {
      var profile = await _profileRepository.GetProfileByIdAsync(profileId);
      return profile;
    }
    public async Task<Profile> AddProfileAsync(string manager, string imageUrl, string linkedinUrl, string phoneNumber, string aboutMe)
    {
      var newProfile= new Profile()
      {
        Manager = manager,
        ImageUrl = imageUrl,
        LinkedInUrl = linkedinUrl,
        PhoneNo = phoneNumber,
        AboutMe = aboutMe
      };
      await _profileRepository.AddProfileAsync(newProfile);

      return newProfile;
    }


    public async Task<Profile> EditProfileAsync(Guid profileId, string manager, string imageUrl, string linkedinUrl, string phoneNumber,
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

    //public async Task<Profile> EditProfileAsync(Guid id, JsonPatchDocument<Profile> value)
    //{
    //  var profile = await _profileRepository.GetProfileByIdAsync(id);
    //  if (profile != null)
    //  {
    //    value.ApplyTo(profile, null);
    //  }

    //}

    public async Task<bool> DeleteProfileAsync(Guid profileId)
    {
      var profileForDeletion = await _profileRepository.GetProfileByIdAsync(profileId);

      if (profileForDeletion!=null)
      {
        await _profileRepository.DeleteProfileByIdAsync(profileId);
        return true;
      }

      return false;
    }
  }
}
