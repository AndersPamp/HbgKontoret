using System;
using System.Collections.Generic;
using System.Text;

namespace HbgKontoret.Data.Entities.Links
{
  public class ProfileCompetence
  {
    public int Id { get; set; }
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; }
    public int CompetenceId { get; set; }
    public Competence Competence { get; set; }
  }
}
