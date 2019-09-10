using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HbgKontoret.Infrastructure.Dto;

namespace HbgKontoret.Infrastructure.Interfaces
{
  public interface IUserRepository
  {
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByIdAsync(Guid id);
    Task<UserDto> AddUserAsync(UserDto userDto);
    Task<UserDto> UpdateUserByIdAsync(Guid id, UserDto userDto);
    Task<bool> DeleteUserByIdAsync(Guid id);
  }
}
