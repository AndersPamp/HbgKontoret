using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HbgKontoret.Data.Entities;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Profile = HbgKontoret.Data.Entities.Profile;

namespace HbgKontoret.Data.Data.Repositories
{
  public class ProfileRepository : IProfileRepository
  {
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public ProfileRepository(AppDbContext appDbContext, IMapper mapper)
    {
      _appDbContext = appDbContext;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ProfileDto>> GetAllProfilesAsync()
    {
      var profiles = await _appDbContext.Profiles.ToListAsync();
      if (profiles != null)
      {
        var profileDtos = _mapper.Map<IEnumerable<Profile>, IEnumerable<ProfileDto>>(profiles);
        return profileDtos;
      }
      return null;
    }

    public async Task<ProfileDto> GetProfileByIdAsync(Guid id)
    {
      var profile = await _appDbContext.Profiles.FirstOrDefaultAsync(x => x.Id == id);
      if (profile != null)
      {
        return _mapper.Map<Profile, ProfileDto>(profile);
      }

      return null;
    }

    public async Task<ProfileDto> AddProfileAsync(ProfileDto profileDto)
    {
      var newProfile = new Profile()
      {
        Manager = profileDto.Manager,
        ImageUrl = profileDto.ImageUrl,
        LinkedInUrl = profileDto.LinkedInUrl,
        PhoneNo = profileDto.PhoneNo,
        AboutMe = profileDto.AboutMe
      };
      await _appDbContext.Profiles.AddAsync(newProfile);
      await _appDbContext.SaveChangesAsync();
      return _mapper.Map<Profile, ProfileDto>(newProfile);
    }

    public async Task<ProfileDto> UpdateUserByIdAsync(Guid id, ProfileDto profileDto)
    {
      var profileForEdit = await _appDbContext.Profiles.FirstOrDefaultAsync(x => x.Id == id);
      profileForEdit.Manager = profileDto.Manager;
      profileForEdit.ImageUrl = profileDto.ImageUrl;
      profileForEdit.LinkedInUrl = profileDto.LinkedInUrl;
      profileForEdit.PhoneNo = profileDto.PhoneNo;
      profileForEdit.AboutMe = profileDto.AboutMe;

      await _appDbContext.SaveChangesAsync();

      return _mapper.Map<Profile, ProfileDto>(profileForEdit);
    }

    public async Task<bool> DeleteProfileByIdAsync(Guid id)
    {
      var profile = await _appDbContext.Profiles.FirstOrDefaultAsync(x => x.Id == id);
      if (profile != null)
      {
        _appDbContext.Profiles.Remove(profile);
        await _appDbContext.SaveChangesAsync();

        return true;
      }

      return false;
    }

    public async Task<IEnumerable<CompetenceDto>> GetCompetencesAsync(Guid profileId)
    {
      var competences = await _appDbContext.Competences.Include(s => s.ProfileCompetences.Where(t => t.ProfileId == profileId)).ToListAsync();
      var competenceDtos = _mapper.Map<IEnumerable<Competence>, IEnumerable<CompetenceDto>>(competences);

      return competenceDtos;
    }

    public async Task<IEnumerable<CompetenceDto>> AddCompetenceAsync(Guid profileId, int competenceId)
    {



      var competences = await _appDbContext.Competences.Include(s => s.ProfileCompetences.Where(t => t.ProfileId == profileId)).ToListAsync();
      var competenceDtos = _mapper.Map<IEnumerable<Competence>, IEnumerable<CompetenceDto>>(competences);

      return competenceDtos;
    }
  }
}
