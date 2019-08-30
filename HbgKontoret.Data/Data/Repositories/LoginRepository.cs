using HbgKontoret.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HbgKontoret.Data.Data.Repositories
{
  public class LoginRepository
  {
    protected readonly AppDbContext _context;
    public LoginRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task AddAsync(Login login)
    {
      await _context.Users.AddAsync(login);
    }

    public async Task<IEnumerable<Login>> GetAll()
    {
      return await _context.Users.ToListAsync();
    }
  }
}
