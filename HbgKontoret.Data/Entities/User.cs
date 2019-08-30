using System;
using System.Collections.Generic;
using System.Text;

namespace HbgKontoret.Data.Entities
{
  public class User
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string ImageUrl { get; set; }
    public string Email { get; set; }
    public string LinkedInUrl { get; set; }
    public IEnumerable<Competence> Competences { get; set; }
    public string About { get; set; }
    
    //Current status/project/
  }
}
