using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HbgKontoret.Data.Data.Repositories;
using HbgKontoret.Data.Entities;
using HbgKontoret.Data.Service.Interfaces;
using HbgKontoret.Data.Helpers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace HbgKontoret.Data.Services
{
  public class LoginService : ILoginService
  {
    private readonly LoginRepository _loginRepository;

    private List<Login> _users = new List<Login>
    {
      new Login{Id= new Guid(), Username = "test", Password = "test"}
    };

    private readonly AppSettings _appSettings;

    public LoginService(IOptions<AppSettings> appSettings, LoginRepository loginRepository)
    {
      _appSettings = appSettings.Value;
      _loginRepository=loginRepository;
    }

    public Login Authenticate(string username, string password)
    {
      var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

      // return null if user not found
      if (user == null)
        return null;

      // authentication successful so generate jwt token
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, user.Id.ToString())
        }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      user.Token = tokenHandler.WriteToken(token);

      // remove password before returning
      user.Password = null;

      return user;
    }

    public IEnumerable<Login> GetAllAuth()
    {
      // return users without passwords
      return _users.Select(x =>
      {
        x.Password = null;
        return x;
      });
    }

    public IEnumerable<Login> GetAll()
    {
      return _loginRepository.GetAll().Result;
    }

    public Task<User> RegisterUser(string password, string userName)
    {
      var newUser= new User();

      
      

      return null;
    }
  }
}
