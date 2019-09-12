using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HbgKontoret.Infrastructure.Dto;

namespace HbgKontoret.Infrastructure.Interfaces
{
  public interface IUserService
  {
    Task<UserDto> AddUserAsync(string username, string password);
    Task<bool> DeleteUserAsync(Guid userId);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    //Task<UserDto> GetUserByIdAsync(Guid userId);
    string Authenticate(string username, string password);
  }
}
