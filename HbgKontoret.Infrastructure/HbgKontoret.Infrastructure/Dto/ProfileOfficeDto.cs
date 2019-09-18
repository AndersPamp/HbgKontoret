using System;
using System.ComponentModel.DataAnnotations;

namespace HbgKontoret.Infrastructure.Dto
{
  public class ProfileOfficeDto
  {
    [Required]
    public Guid ProfileId { get; set; }
    [Required]
    public int OfficeId { get; set; }
  }
}