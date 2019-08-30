using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HbgKontoret.Data.Entities;

namespace HbgKontoret.Data.Service.Interfaces
{
  public interface ILoginService
  {
    Login Authenticate(string username, string password);
    IEnumerable<Login> GetAll();
    IEnumerable<Login> RegisterUser(string userName, string password);
  }
}
