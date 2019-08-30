using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HbgKontoret.Data.Entities.Links
{
  class ProfileOffice
  {
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; }
    public int OfficeId { get; set; }
    public Office Office { get; set; }
  }
}
