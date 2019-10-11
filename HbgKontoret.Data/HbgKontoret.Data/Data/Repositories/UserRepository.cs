using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HbgKontoret.Data.Entities;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HbgKontoret.Data.Data.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public UserRepository(AppDbContext appDbContext, IMapper mapper)
    {
      _appDbContext = appDbContext;
      _mapper = mapper;
    }
    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
      try
      {
        var users = await _appDbContext.Users.Include(x=>x.Role).ToListAsync();

        if (users==null || users.Count == 0)
        {
          return null;
        }
        var userDtos = new List<UserDto>();

        foreach (var user in users)
        {
          var userDto = new UserDto
          {
            Id = user.Id,
            Email = user.Email,
            ProfileDtoId = user.ProfileId,
            Password = user.Password,
          };
          if (user.Role!=null)
          {
            var roleDto = new RoleDto { Id = user.Role.Id, Name = user.Role.Name };
            userDto.RoleDto = roleDto;
          }
          userDtos.Add(userDto);
        }
        return userDtos;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
      try
      {
        var user = await _appDbContext.Users.Include(x => x.Role).Include(x=>x.Profile).FirstOrDefaultAsync(x => x.Id == id);

        if (user != null)
        {
          var roleDto = new RoleDto { Id = user.Role.Id, Name = user.Role.Name };

          var userDto = new UserDto { Id = user.Id, Email = user.Email, Password = user.Password, ProfileDtoId = user.ProfileId, RoleDto = roleDto };

          return userDto;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

      return null;
    }
    public async Task<UserDto> AddUserAsync(UserDto userDto)
    {
      try
      {
        var user = _mapper.Map<UserDto, User>(userDto);

        var checkIfExist = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);

        if (checkIfExist == null)
        {
          var result = await _appDbContext.Users.AddAsync(user);
          if (result != null)
          {
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<User, UserDto>(user);
          }
        }
        return null;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

      
    }
    public async Task<UserDto> UpdateUserByIdAsync(Guid id, UserDto userDto)
    {
      try
      {
        var userForUpdate = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (userForUpdate != null)
        {
          userForUpdate.Email = userDto.Email;
          userForUpdate.Password = userDto.Password;
          userForUpdate.Role.Id = userDto.RoleDto.Id;

          _appDbContext.Users.Update(userForUpdate);
          await _appDbContext.SaveChangesAsync();

          var newUserDto = _mapper.Map<User, UserDto>(await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id));

          return newUserDto;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
      return null;
    }
    public async Task<bool> DeleteUserByIdAsync(Guid id)
    {
      try
      {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user != null)
        {
          _appDbContext.Users.Remove(user);
          await _appDbContext.SaveChangesAsync();
          return true;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

      return false;
    }
  }
}
