using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HbgKontoret.Infrastructure.Dto;

namespace HbgKontoret.Infrastructure.Interfaces
{
  public interface ILoginService
  {
    //Login Authenticate(string username, string password);
    //IEnumerable<Login> GetAll();
    Task<UserDto> RegisterUser(string password, string userName);
  }
}
