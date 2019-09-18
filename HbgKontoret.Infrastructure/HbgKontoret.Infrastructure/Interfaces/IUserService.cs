using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using HbgKontoret.Infrastructure.Dto;
using Microsoft.IdentityModel.Tokens;

namespace HbgKontoret.Infrastructure.Interfaces
{
  public interface IUserService
  {
    Task<UserDto> AddUserAsync(string username, string password);
    Task<bool> DeleteUserAsync(Guid userId);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    string Authenticate(string username, string password);
  }
}
