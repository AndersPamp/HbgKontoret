using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HbgKontoret.Data.Entities.Links;

namespace HbgKontoret.Data.Services
{
  public interface IProfileOfficeService
  {
    Task<ProfileOffice> AddProfileOfficeAsync(ProfileOffice profileOffice);
    Task<ProfileOffice> EditProfileOfficeAsync(int id, ProfileOffice profileOffice);
  }
}
