﻿using HbgKontoret.Data.Entities;
using HbgKontoret.Data.Entities.Links;
using HbgKontoret.Infrastructure.Dto;
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
            CreateMap<ProfileCompetenceDto, ProfileCompetence>();
            CreateMap<ProfileOfficeDto, ProfileOffice>();
            CreateMap<RoleDto, Role>();
        }
    }
}
