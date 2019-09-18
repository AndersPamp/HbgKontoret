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
    public Guid? ProfileId { get; set; } = Guid.Empty;
    public Role Role { get; set; }
  }
}
