using System;
using System.Collections.Generic;
using System.Text;

namespace HbgKontoret.Data.Entities.Dto
{
  public class UserDto
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
  }
}
