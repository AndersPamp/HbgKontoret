using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HbgKontoret.Infrastructure.Dto
{
  public class UserDto
  {
    public Guid Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public Guid? ProfileId { get; set; } = Guid.Empty;
    public RoleDto RoleDto { get; set; }
  }
}
