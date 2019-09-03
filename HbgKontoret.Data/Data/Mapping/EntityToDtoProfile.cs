using System;
using System.Collections.Generic;
using System.Text;
using HbgKontoret.Data.Entities;
using HbgKontoret.Data.Entities.Dto;
using Profile = AutoMapper.Profile;

namespace HbgKontoret.Data.Data.Mapping
{
  class EntityToDtoProfile : Profile
  {
    public EntityToDtoProfile()
    {
      CreateMap<Competence, CompetenceDto>();
      CreateMap<Office, OfficeDto>();
      CreateMap<Entities.Profile, ProfileDto>();
      CreateMap<User, UserDto>();
    }
  }
}
