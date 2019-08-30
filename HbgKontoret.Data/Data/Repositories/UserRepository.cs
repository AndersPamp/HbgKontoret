using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HbgKontoret.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HbgKontoret.Data.Data.Repositories
{
  class UserRepository
  {
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }

    public async Task<User> AddUserAsync(string firstName, string lastName, string email)
    {
      var newUser = new User()
      {
        FirstName = firstName,
        LastName = lastName,
        Email = email
      };

      var result = await _appDbContext.Users.AddAsync(newUser);

      if (result != null)
      {
        return newUser;
      }

      return null;

    }
  }
}
