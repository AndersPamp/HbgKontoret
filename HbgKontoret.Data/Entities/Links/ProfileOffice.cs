using System;
using System.Collections.Generic;
using System.Text;

namespace HbgKontoret.Data.Entities.Links
{
  public class ProfileOffice
  {
    //public int Id { get; set; }
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; }
    public int OfficeId { get; set; }
    public Office Office { get; set; }
  }
}
