using System;
using System.ComponentModel.DataAnnotations;

namespace HbgKontoret.Infrastructure.Dto
{
  public class ProfileCompetenceDto
  {
    [Required]
    public Guid ProfileId { get; set; }
    [Required]
    public int CompetenceId { get; set; }
  }
}