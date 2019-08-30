using System;

namespace HbgKontoret.Data.Entities.Links
{
  class ProfileCompetence
  {
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; }
    public int CompetenceId { get; set; }
    public Competence Competence { get; set; }
  }
}
