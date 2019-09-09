using System.Collections.Generic;
using HbgKontoret.Data.Entities.Links;

namespace HbgKontoret.Data.Entities
{
  public class Office
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Manager { get; set; }
    public IList<ProfileOffice> ProfileOffices { get; set; }

  }
}
