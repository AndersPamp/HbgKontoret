using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HbgKontoret.Data.Entities.Links;

namespace HbgKontoret.Data.Services.Interfaces
{
  public interface IProfileCompetenceService
  {
    Task<ProfileCompetence> AddProfileCompetenceAsync(ProfileCompetence profileCompetence);
    Task<ProfileCompetence> EditProfileCompetenceAsync(int id, ProfileCompetence profileCompetence);
  }
}
