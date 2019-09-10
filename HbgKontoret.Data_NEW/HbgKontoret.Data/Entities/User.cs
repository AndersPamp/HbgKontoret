using System;

namespace HbgKontoret.Data.Entities
{
  public class User
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Profile Profile { get; set; }  

    //Current status/project/
  }
}
