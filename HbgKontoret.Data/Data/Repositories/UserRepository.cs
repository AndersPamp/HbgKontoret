using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using HbgKontoret.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HbgKontoret.Data.Data.Repositories
{
  public class UserRepository
  {
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }
    public async Task<IEnumerable<User>> GetAllUsers()
    {
      var users = await _appDbContext.Users.ToListAsync();
      return users;
    }
    public async Task<User> GetUserById(Guid id)
    {
      var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

      if (user != null)
      {
        return user;
      }

      return null;
    }
    public async Task<User> AddUserAsync(User user)
    {
      await _appDbContext.Users.AddAsync(user);

      await _appDbContext.SaveChangesAsync();
      return user;

    }
    public async Task<User> UpdateUserById(User user)
    {
      var userForUpdate = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

      if (userForUpdate != null)
      {
        userForUpdate.FirstName = user.FirstName;
        userForUpdate.LastName = user.LastName;
        userForUpdate.Email = user.Email;

        _appDbContext.Users.Update(userForUpdate);
        await _appDbContext.SaveChangesAsync();

        return userForUpdate;
      }

      return null;
    }
    public async Task<bool> DeleteUserById(Guid id)
    {
      var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
      if (user != null)
      {
        _appDbContext.Users.Remove(user);
        await _appDbContext.SaveChangesAsync();
        return true;
      }

      return false;
    }
  }
}
