using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HbgKontoret.Data.Data.Repositories;
using HbgKontoret.Data.Entities;
using HbgKontoret.Data.Entities.Dto;
using HbgKontoret.Data.Services.Interfaces;

namespace HbgKontoret.Data.Services
{
  public class UserService : IUserService
  {
    private readonly UserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(UserRepository userRepository, IMapper mapper)
    {
      _userRepository = userRepository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
      var users = await _userRepository.GetAllUsers();
      var userDtos = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);


      return userDtos;
    }

    public async Task<UserDto> GetUserByIdAsync(Guid userId)
    {
      var user = await _userRepository.GetUserById(userId);
      if (user!=null)
      {
        var userDtos = _mapper.Map<User, UserDto>(user);
        return userDtos;
      }

      return null;
    }

    public async Task<User> AddUserAsync(string firstName, string lastName, string email)
    {
      var newUser = new User
      {
        FirstName = firstName,
        LastName = lastName,
        Email = email,
      };
      return await _userRepository.AddUserAsync(newUser);

    }

    public async Task<User> EditUserAsync(Guid userId, string firstName, string lastName, string email)
    {
      var userForEdit = await _userRepository.GetUserById(userId);
      if (userForEdit!=null)
      {
        userForEdit.FirstName = firstName;
        userForEdit.LastName = lastName;
        userForEdit.Email = email;

        await _userRepository.UpdateUserById(userForEdit);

      }

      return null;
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
      if (await _userRepository.DeleteUserById(userId) == true)
      {
        return true;
      }

      return false;
    }
  }
}
