using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HbgKontoret.Data.Entities.Links;
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
      try
      {
        var profiles = await _appDbContext.Profiles.ToListAsync();
        if (profiles == null || profiles.Count == 0)
        {
          return null;
        }
        var profileDtos = _mapper.Map<IEnumerable<Profile>, IEnumerable<ProfileDto>>(profiles);
        return profileDtos;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProfileDto> GetProfileByIdAsync(Guid id)
    {
      try
      {
        var profile = await _appDbContext.Profiles.Include(x => x.ProfileOffices).ThenInclude(x => x.Office)
          .Include(x => x.ProfileCompetences).ThenInclude(x => x.Competence).FirstOrDefaultAsync(x => x.Id == id);
        if (profile == null)
        {
          return null;
        }

        var profileDto = new ProfileDto
        {
          Id = profile.Id,
          FirstName = profile.FirstName,
          LastName = profile.LastName,
          Manager = profile.Manager,
          ImageUrl = profile.ImageUrl,
          LinkedInUrl = profile.LinkedInUrl,
          PhoneNo = profile.PhoneNo,
          AboutMe = profile.AboutMe,
          CompetenceDtos = profile.ProfileCompetences.Where(ct => ct.ProfileId == profile.Id).Select(ct =>
            new CompetenceDto
            {
              Id = ct.Competence.Id,
              Name = ct.Competence.Name
            }).ToList(),
          OfficeDtos = profile.ProfileOffices.Where(of => of.ProfileId == profile.Id).Select(of => new OfficeDto
          {
            Id = of.Office.Id,
            Name = of.Office.Name,
            Address = of.Office.Address,
            Manager = of.Office.Manager,
            Phone = of.Office.Phone
          }).ToList()
        };
        return profileDto;

      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    #region lambda alternative
    //var queryResult = 
    //  from ct in profile.ProfileCompetences
    //  where ct.ProfileId == profile.Id
    //  select new Competence()
    //  {
    //    Id = ct.Competence.Id,
    //    Name = ct.Competence.Name
    //  };

    #endregion

    public async Task<ProfileDto> AddProfileAsync(ProfileDto profileDto)
    {
      try
      {
        var newProfile = new Profile()
        {
          FirstName = profileDto.FirstName,
          LastName = profileDto.LastName,
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
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProfileDto> UpdateProfileByIdAsync(Guid id, ProfileDto profileDto)
    {
      try
      {
        var profileForEdit = await _appDbContext.Profiles.FirstOrDefaultAsync(x => x.Id == id);
        if (profileForEdit==null)
        {
          return null;
        }

        profileForEdit.FirstName = profileDto.FirstName;
        profileForEdit.LastName = profileDto.LastName;
        profileForEdit.Manager = profileDto.Manager;
        profileForEdit.ImageUrl = profileDto.ImageUrl;
        profileForEdit.LinkedInUrl = profileDto.LinkedInUrl;
        profileForEdit.PhoneNo = profileDto.PhoneNo;
        profileForEdit.AboutMe = profileDto.AboutMe;

        await _appDbContext.SaveChangesAsync();

        return _mapper.Map<Profile, ProfileDto>(profileForEdit);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<bool> DeleteProfileByIdAsync(Guid id)
    {
      try
      {
        var profile = await _appDbContext.Profiles.FirstOrDefaultAsync(x => x.Id == id);
        if (profile != null)
        {
          _appDbContext.Profiles.Remove(profile);
          await _appDbContext.SaveChangesAsync();

          return true;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
      return false;
    }

    public async Task<ProfileCompetenceDto> AddProfileCompetenceAsync(ProfileCompetenceDto profileCompetenceDto)
    {
      try
      {
        var newProfileCompetence = new ProfileCompetence
        {
          ProfileId = profileCompetenceDto.ProfileId,
          CompetenceId = profileCompetenceDto.CompetenceId
        };
        await _appDbContext.ProfileCompetences.AddAsync(newProfileCompetence);
        await _appDbContext.SaveChangesAsync();

        return _mapper.Map<ProfileCompetence, ProfileCompetenceDto>(newProfileCompetence);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<bool> DeleteProfileCompetenceAsync(ProfileCompetenceDto profileCompetenceDto)
    {
      try
      {
        var pcForDeletion = await _appDbContext.ProfileCompetences.Where(pid => pid.ProfileId == profileCompetenceDto.ProfileId)
          .FirstOrDefaultAsync(cid => cid.CompetenceId == profileCompetenceDto.CompetenceId);

        if (pcForDeletion != null)
        {
          _appDbContext.ProfileCompetences.Remove(pcForDeletion);
          await _appDbContext.SaveChangesAsync();
          return true;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
      return false;
    }

    public async Task<ProfileOfficeDto> AddProfileOfficeAsync(ProfileOfficeDto profileOfficeDto)
    {
      try
      {
        var newProfileOffice = new ProfileOffice
        {
          ProfileId = profileOfficeDto.ProfileId,
          OfficeId = profileOfficeDto.OfficeId
        };
        await _appDbContext.ProfileOffices.AddAsync(newProfileOffice);
        await _appDbContext.SaveChangesAsync();
        return _mapper.Map<ProfileOffice, ProfileOfficeDto>(newProfileOffice);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<bool> DeleteProfileOfficeAsync(ProfileOfficeDto profileOfficeDto)
    {
      try
      {
        var poForDeletion = await _appDbContext.ProfileOffices.Where(pid => pid.ProfileId == profileOfficeDto.ProfileId)
          .FirstOrDefaultAsync(oid => oid.OfficeId == profileOfficeDto.OfficeId);

        if (poForDeletion != null)
        {
          _appDbContext.ProfileOffices.Remove(poForDeletion);
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
