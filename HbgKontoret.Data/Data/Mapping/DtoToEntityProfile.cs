using System;
using System.Collections.Generic;
using System.Text;
using HbgKontoret.Data.Entities;
using HbgKontoret.Data.Entities.Dto;
using Profile = AutoMapper.Profile;

namespace HbgKontoret.Data.Data.Mapping
{
  public class DtoToEntityProfile : Profile
  {
    public DtoToEntityProfile()
    {
      CreateMap<ProfileDto, Entities.Profile>();
      CreateMap<CompetenceDto, Competence>();
      CreateMap<OfficeDto, Office>();
      CreateMap<UserDto, User>();
    }
  }
}
