using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HbgKontoret.Entities;

namespace HbgKontoret.Service.Interfaces
{
  public interface IUserService
  {
    User Authenticate(string username, string password);
    IEnumerable<User> GetAll();
  }
}
