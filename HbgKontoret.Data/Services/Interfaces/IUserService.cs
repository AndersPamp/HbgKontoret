using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HbgKontoret.Data.Entities;
using HbgKontoret.Data.Entities.Dto;

namespace HbgKontoret.Data.Services.Interfaces
{
  public interface IUserService
  {
    Task<User> AddUserAsync(string firstName, string lastName, string email);
    Task<bool> DeleteUserAsync(Guid userId);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByIdAsync(Guid userId);
    Task<User> EditUserAsync(Guid userId, string firstName, string lastName, string email);
  }
}
