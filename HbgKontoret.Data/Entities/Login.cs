using System;
using System.Collections.Generic;

namespace HbgKontoret.Data.Entities
{
  public class Login
  {
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
    public IEnumerable<Role> Roles { get; set; }
  }
}
