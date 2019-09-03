using System;
using System.Collections.Generic;
using System.Text;

namespace HbgKontoret.Infrastructure.Dto
{
  public class ProfileDto
  {
    public Guid Id { get; set; }
    public string Manager { get; set; }
    public string ImageUrl { get; set; }
    public string LinkedInUrl { get; set; }
    public string PhoneNo { get; set; }
    public string AboutMe { get; set; }
  }
}
