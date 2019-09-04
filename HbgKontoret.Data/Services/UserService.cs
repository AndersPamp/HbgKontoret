using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;

namespace HbgKontoret.Data.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
      var userDtos = await _userRepository.GetAllUsersAsync();

      if (userDtos!=null)
      {
        return userDtos;
      }

      return null;
    }

    public async Task<UserDto> GetUserByIdAsync(Guid userId)
    {
      var userDto = await _userRepository.GetUserByIdAsync(userId);
      if (userDto!=null)
      {
        return userDto;
      }
      return null;
    }

    public async Task<UserDto> AddUserAsync(string firstName, string lastName, string email)
    {
      var newUserDto = new UserDto()
      {
        FirstName = firstName,
        LastName = lastName,
        Email = email,
      };
      return await _userRepository.AddUserAsync(newUserDto);

    }

    public async Task<UserDto> EditUserAsync(Guid userId, string firstName, string lastName, string email)
    {
      var userForEdit = await _userRepository.GetUserByIdAsync(userId);
      if (userForEdit!=null)
      {
        userForEdit.FirstName = firstName;
        userForEdit.LastName = lastName;
        userForEdit.Email = email;

        await _userRepository.UpdateUserByIdAsync(userId, userForEdit);

      }

      return null;
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
      if (await _userRepository.DeleteUserByIdAsync(userId) == true)
      {
        return true;
      }

      return false;
    }
  }
}
