using System;

namespace HbgKontoret.Data.Entities.Links
{
  public class ProfileOffice
  {
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; }
    public int OfficeId { get; set; }
    public Office Office { get; set; }
  }
}
