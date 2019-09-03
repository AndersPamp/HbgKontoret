using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HbgKontoret.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HbgKontoret.Data.Data.Repositories
{
  public class ProfileRepository
  {
    private readonly AppDbContext _appDbContext;

    public ProfileRepository(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Profile>> GetAllProfilesAsync()
    {
      var profiles = await _appDbContext.Profiles.ToListAsync();
      return profiles;
    }

    public async Task<Profile> GetProfileByIdAsync(Guid id)
    {
      var profile = await _appDbContext.Profiles.FirstOrDefaultAsync(x => x.Id == id);
      if (profile != null)
      {
        return profile;
      }

      return null;
    }

    public async Task<Profile> AddProfileAsync(Profile profile)
    {
      var newProfile = new Profile()
      {
        Manager = profile.Manager,
        ImageUrl = profile.ImageUrl,
        LinkedInUrl = profile.LinkedInUrl,
        PhoneNo = profile.PhoneNo,
        AboutMe = profile.AboutMe
      };
      await _appDbContext.Profiles.AddAsync(profile);
      await _appDbContext.SaveChangesAsync();
      return profile;
    }

    public async Task<Profile> UpdateUserByIdAsync(Guid id, Profile profile)
    {
      var profileForEdit = await _appDbContext.Profiles.FirstOrDefaultAsync(x => x.Id == id);
      profileForEdit.Manager = profile.Manager;
      profileForEdit.ImageUrl = profile.ImageUrl;
      profileForEdit.LinkedInUrl = profile.LinkedInUrl;
      profileForEdit.PhoneNo = profile.PhoneNo;
      profileForEdit.AboutMe = profile.AboutMe;

      await _appDbContext.SaveChangesAsync();

      return profileForEdit;

    }

    public async Task<bool> DeleteProfileByIdAsync(Guid id)
    {
      var profile = await _appDbContext.Profiles.FirstOrDefaultAsync(x => x.Id == id);
      if (profile!=null)
      {
        _appDbContext.Profiles.Remove(profile);
        await _appDbContext.SaveChangesAsync();

        return true;
      }

      return false;
    }
  }
}
