using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HbgKontoret.Data.Communication;
using HbgKontoret.Data.Entities;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HbgKontoret.Data.Data.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public UserRepository(AppDbContext appDbContext, IMapper mapper)
    {
      _appDbContext = appDbContext;
      _mapper = mapper;
    }
    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
      var users = await _appDbContext.Users.ToListAsync();
      var userDtos = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
      return userDtos;
    }
    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
      var user = await _appDbContext.Users.Include(pr => pr.ProfileId).FirstOrDefaultAsync(x => x.Id == id);

      if (user != null)
      {
        var profile = await _appDbContext.Profiles.Include(x => x.ProfileOffices).ThenInclude(x => x.Office).
          Include(x => x.ProfileCompetences).
          ThenInclude(x => x.Competence).FirstOrDefaultAsync(x => x.Id == user.ProfileId);

        var userDto = _mapper.Map<User, UserDto>(user);
        {
          //userDto.ProfileDto = new ProfileDto
          //{

          //};

          //var profileDto = new ProfileDto
          //{
          //  Id = profile.Id,
          //  Manager = profile.Manager,
          //  ImageUrl = profile.ImageUrl,
          //  LinkedInUrl = profile.LinkedInUrl,
          //  PhoneNo = profile.PhoneNo,
          //  AboutMe = profile.AboutMe,
          //  CompetenceDtos = profile.ProfileCompetences.Where(ct => ct.ProfileId == profile.Id).Select(ct => new CompetenceDto
          //  {
          //    Id = ct.Competence.Id,
          //    Name = ct.Competence.Name
          //  }).ToList(),
          //  OfficeDtos = profile.ProfileOffices.Where(of => of.ProfileId == profile.Id).Select(of => new OfficeDto
          //  {
          //    Id = of.Office.Id,
          //    Name = of.Office.Name,
          //    Address = of.Office.Address,
          //    Manager = of.Office.Manager,
          //    Phone = of.Office.Phone
          //  }).ToList()
          //};
          //userDto.ProfileDto = profileDto;
          //return userDto;
          return null;
        };
      }

      return null;
    }
    public async Task<UserDto> AddUserAsync(UserDto userDto)
    {
      var user = _mapper.Map<UserDto, User>(userDto);

      var checkIfExist = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);

      if (checkIfExist == null)
      {
        var result = await _appDbContext.Users.AddAsync(user);
        if (result != null)
        {
          await _appDbContext.SaveChangesAsync();
          return _mapper.Map<User, UserDto>(user);
        }
      }
      return null;
    }

    public async Task<UserDto> UpdateUserByIdAsync(Guid id, UserDto userDto)
    {
      var userForUpdate = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

      if (userForUpdate != null)
      {
        //userForUpdate.FirstName = userDto.FirstName;
        //userForUpdate.LastName = userDto.LastName;
        //userForUpdate.Email = userDto.Email;

        //_appDbContext.Users.Update(userForUpdate);
        //await _appDbContext.SaveChangesAsync();

        //var newUserDto = _mapper.Map<User, UserDto>(await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id));

        //return newUserDto;
      }

      return null;
    }
    public async Task<bool> DeleteUserByIdAsync(Guid id)
    {
      var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
      if (user != null)
      {
        _appDbContext.Users.Remove(user);
        await _appDbContext.SaveChangesAsync();
        return true;
      }

      return false;
    }
  }
}
