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
      var userDtos = await _userRepository.GetAllUsersAsync();

      //Remove pwd before sending out
      return userDtos.Select(x =>
      {
        x.Password = null;
        return x;
      });
    }

    //public async Task<UserDto> GetUserByIdAsync(Guid userId)
    //{
    //  var userDto = await _userRepository.GetUserByIdAsync(userId);
    //  if (userDto!=null)
    //  {
    //    userDto.Password = null;
    //    return userDto;
    //  }
    //  return null;
    //}

    public async Task<UserDto> AddUserAsync(string username, string password)
    {
      var user = _userRepository.GetAllUsersAsync().Result.SingleOrDefault(x => x.Email == username);

      if (user!=null)
      {
        var newUserDto = new UserDto()
        {
          Email = username,
          Password = password
        };
        return await _userRepository.AddUserAsync(newUserDto);
      }

      return null;
    }

    //public async Task<UserDto> EditUserAsync(Guid userId, string firstName, string lastName, string email)
    //{
    //  var userForEdit = await _userRepository.GetUserByIdAsync(userId);
    //  if (userForEdit != null)
    //  {
    //    //userForEdit.FirstName = firstName;
    //    //userForEdit.LastName = lastName;
    //    userForEdit.Email = email;

    //    await _userRepository.UpdateUserByIdAsync(userId, userForEdit);

    //  }

    //  return null;
    //}

    public string Authenticate(string username, string password)
    {
      var userDto = _userRepository.GetAllUsersAsync().Result
        .SingleOrDefault(x => x.Email == username && x.Password == password);

      if (userDto!=null)
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

      var token = tokenHandler.CreateToken(tokenDescriptor);
      //userDto.Token = tokenHandler.WriteToken(token);

      userDto.Password = null;

      return token.ToString();
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
      if (await _userRepository.DeleteUserByIdAsync(userId))
      {
        return true;
      }

      return false;
    }
  }
}
