using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HbgKontoret.Infrastructure.Dto;

namespace HbgKontoret.Infrastructure.Interfaces
{
  public interface IUserService
  {
    Task<UserDto> AddUserAsync(string firstName, string lastName, string email);
    Task<bool> DeleteUserAsync(Guid userId);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByIdAsync(Guid userId);
    Task<UserDto> EditUserAsync(Guid userId, string firstName, string lastName, string email);
  }
}
