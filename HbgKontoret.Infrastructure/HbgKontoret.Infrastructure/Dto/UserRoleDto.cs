namespace HbgKontoret.Infrastructure.Dto
{
  public class UserRoleDto
  {
    public int UserId { get; set; }
    public UserDto UserDto { get; set; }
    public int RoleId { get; set; }
    public RoleDto RoleDto { get; set; }
  }
}