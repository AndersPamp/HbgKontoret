using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HbgKontoret.Data.Data;
using HbgKontoret.Data.Entities.Links;
using HbgKontoret.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HbgKontoret.Data.Services
{
  class ProfileCompetenceService:IProfileCompetenceService
  {
    private readonly AppDbContext _appDbContext;

    public ProfileCompetenceService(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }
    public async Task<ProfileCompetence> AddProfileCompetenceAsync(ProfileCompetence profileCompetence)
    {
      var newPc=new ProfileCompetence()
      {
        ProfileId = profileCompetence.ProfileId,
        CompetenceId = profileCompetence.CompetenceId

      };
      await _appDbContext.ProfileCompetences.AddAsync(profileCompetence);
      await _appDbContext.SaveChangesAsync();

      return profileCompetence;
    }

    public async Task<ProfileCompetence> EditProfileCompetenceAsync(int id, ProfileCompetence profileCompetence)
    {
      var pc = await _appDbContext.ProfileCompetences.FirstOrDefaultAsync(x => x.Id == id);
      pc.CompetenceId = profileCompetence.CompetenceId;
      await _appDbContext.SaveChangesAsync();

      return profileCompetence;
    }
  }
}
