using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HbgKontoret.Data.Helpers;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HbgKontoret.Data.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;
    private readonly AppSettings _appSettings;

    public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
    {
      _userRepository = userRepository;
      _appSettings = appSettings.Value;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
      try
      {
        var userDtos = await _userRepository.GetAllUsersAsync();

        //Remove pwd before sending out
        return userDtos.Select(x =>
        {
          x.Password = null;
          return x;
        });
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
        var userDto = await _userRepository.GetUserByIdAsync(id);
        userDto.Password = null;
        return userDto;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message.ToString());
      }
    }

    public string Authenticate(string username, string password)
    {
      var userDto = _userRepository.GetAllUsersAsync().Result
        .FirstOrDefault(x => x.Email == username && x.Password == password);

      if (userDto == null)
      {
        return null;
      }

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, userDto.Id.ToString()),
        }),
        Expires = DateTime.UtcNow.AddHours(12),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      //var userIdClaim = tokenDescriptor.Subject.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
      //var userIdValue = userIdClaim.Value;

      var jwtToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
      var token = tokenHandler.WriteToken(jwtToken);

      

      userDto.Password = null;

      return token;
    }

    public async Task<UserDto> AddUserAsync(string username, string password)
    {
      try
      {
        var newUserDto = new UserDto
        {
          Email = username,
          Password = password
        };
        var result = await _userRepository.AddUserAsync(newUserDto);
        if (result != null)
        {
          result.Password = null;
          return result;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message.ToString());
      }

      return null;
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
      try
      {
        if (await _userRepository.DeleteUserByIdAsync(userId))
        {
          return true;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

      return false;
    }

    public async Task<UserDto> UpdateUserByIdAsync(Guid userId, UserDto userDto)
    {
      return await _userRepository.UpdateUserByIdAsync(userId, userDto);
      
    }
  }
}
