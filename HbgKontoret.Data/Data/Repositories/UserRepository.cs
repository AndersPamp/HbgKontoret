using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using HbgKontoret.Data.Entities;
using HbgKontoret.Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;

namespace HbgKontoret.Data.Data.Repositories
{
  public class UserRepository
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
      var users = await _appDbContext.Users.ToListAsync();
      var userDtos = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
      return userDtos;
    }
    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
      var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
      
      if (user != null)
      {
        return _mapper.Map<User, UserDto>(user);
      }

      return null;
    }
    public async Task<UserDto> AddUserAsync(UserDto userDto)
    {
      var user = _mapper.Map<UserDto, User>(userDto);

      await _appDbContext.Users.AddAsync(user);

      await _appDbContext.SaveChangesAsync();
      return userDto;

    }
    public async Task<UserDto> UpdateUserByIdAsync(Guid id, UserDto userDto)
    {
      var userForUpdate = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

      if (userForUpdate != null)
      {
        userForUpdate.FirstName = userDto.FirstName;
        userForUpdate.LastName = userDto.LastName;
        userForUpdate.Email = userDto.Email;

        _appDbContext.Users.Update(userForUpdate);
        await _appDbContext.SaveChangesAsync();

        var newUserDto = _mapper.Map<User, UserDto>(await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id));

        return newUserDto;
      }

      return null;
    }
    public async Task<bool> DeleteUserByIdAsync(Guid id)
    {
      var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
      if (user != null)
      {
        _appDbContext.Users.Remove(user);
        await _appDbContext.SaveChangesAsync();
        return true;
      }

      return false;
    }
  }
}
