using System;
using System.ComponentModel.DataAnnotations;

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
    public int? RoleId { get; set; } = 1;
  }
}
