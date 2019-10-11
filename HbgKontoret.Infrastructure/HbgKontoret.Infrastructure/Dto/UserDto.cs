using System;
using System.ComponentModel.DataAnnotations;

namespace HbgKontoret.Infrastructure.Dto
{
  public class UserDto
  {
    public Guid Id { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public Guid? ProfileDtoId { get; set; }
    public ProfileDto ProfileDto { get; set; }
    public int RoleDtoId { get; set; }
    public RoleDto RoleDto { get; set; }
  }
}
