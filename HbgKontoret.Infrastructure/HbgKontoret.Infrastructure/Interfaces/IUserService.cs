﻿using System;
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
    Task<UserDto> GetUserByIdAsync(Guid id);
    string Authenticate(string username, string password);
    Task<UserDto> UpdateUserByIdAsync(Guid userId, UserDto userDto);
  }
}
