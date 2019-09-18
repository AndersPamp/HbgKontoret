using System;
using System.ComponentModel.DataAnnotations;

namespace HbgKontoret.Data.Entities.Links
{
  public class ProfileOffice
  {
    [Required]
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; }
    [Required]
    public int OfficeId { get; set; }
    public Office Office { get; set; }
  }
}
