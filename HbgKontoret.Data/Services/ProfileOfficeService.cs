//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using HbgKontoret.Data.Data;
//using HbgKontoret.Data.Entities.Links;
//using Microsoft.EntityFrameworkCore;

//namespace HbgKontoret.Data.Services
//{
//  public class ProfileOfficeService : IProfileOfficeService
//  {
//    private readonly AppDbContext _appDbContext;

//    public ProfileOfficeService(AppDbContext appDbContext)
//    {
//      _appDbContext = appDbContext;
//    }
//    public async Task<ProfileOffice> AddProfileOfficeAsync(ProfileOffice profileOffice)
//    {
//      var newPo = new ProfileOffice()
//      {
//        ProfileId = profileOffice.ProfileId,
//        OfficeId = profileOffice.OfficeId
//      };

//      await _appDbContext.ProfileOffices.AddAsync(profileOffice);
//      await _appDbContext.SaveChangesAsync();
//      return profileOffice;
//    }

//    public async Task<ProfileOffice> EditProfileOfficeAsync(int id, ProfileOffice profileOffice)
//    {
//      var po = await _appDbContext.ProfileOffices.FirstOrDefaultAsync(x => x.Id == id);
//      po.OfficeId = profileOffice.OfficeId;
//      po.ProfileId = profileOffice.ProfileId;

//      await _appDbContext.SaveChangesAsync();
//      return profileOffice;
//    }
//  }
//}
