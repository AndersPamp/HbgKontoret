using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HbgKontoret.Data.Entities.Links;

namespace HbgKontoret.Data.Entities
{
  public class User
  {
    public Guid Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public Guid? ProfileId { get; set; }
    public Profile Profile { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
  }
}
