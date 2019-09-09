using System;
using System.Collections.Generic;
using System.Text;
using HbgKontoret.Data.Entities.Links;

namespace HbgKontoret.Data.Entities
{
  public class Profile
  {
    public Guid Id { get; set; }
    public string Manager { get; set; }
    public string ImageUrl { get; set; }
    public string LinkedInUrl { get; set; }
    public string PhoneNo { get; set; }
    public string AboutMe { get; set; }
    public IList<ProfileCompetence> ProfileCompetences { get; set; }
    public IList<ProfileOffice> ProfileOffices { get; set; }  
  }
}
