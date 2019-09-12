using HbgKontoret.Data.Entities;
using HbgKontoret.Data.Entities.Links;
using HbgKontoret.Infrastructure.Dto;
using Profile = AutoMapper.Profile;

namespace HbgKontoret.Data.Data.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Competence, CompetenceDto>();
            CreateMap<Office, OfficeDto>();
            CreateMap<Entities.Profile, ProfileDto>();
            CreateMap<User, UserDto>();
            CreateMap<ProfileOffice, ProfileOfficeDto>();
            CreateMap<ProfileCompetence, ProfileCompetenceDto>();
            CreateMap<RoleDto, Role>();
        }
    }
}
