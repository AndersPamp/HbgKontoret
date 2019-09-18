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
    public Guid ProfileDtoId { get; set; } = Guid.Empty;
    public int? RoleId { get; set; } = 1;
  }
}
