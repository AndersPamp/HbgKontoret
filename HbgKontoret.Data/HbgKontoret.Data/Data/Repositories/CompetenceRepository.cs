using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HbgKontoret.Data.Entities;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HbgKontoret.Data.Data.Repositories
{
  public class CompetenceRepository : ICompetenceRepository
  {
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public CompetenceRepository(AppDbContext appDbContext, IMapper mapper)
    {
      _appDbContext = appDbContext;
      _mapper = mapper;
    }
    public async Task<IEnumerable<CompetenceDto>> GetAllCompetencesAsync()
    {
      try
      {
        var competences = await _appDbContext.Competences.ToListAsync();
        if (competences != null)
        {
          var competenceDtos = _mapper.Map<IEnumerable<Competence>, IEnumerable<CompetenceDto>>(competences);
          return competenceDtos;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
      return null;
    }

    public async Task<CompetenceDto> GetCompetenceByIdAsync(int id)
    {
      try
      {
        var competence = await _appDbContext.Competences.FirstOrDefaultAsync(ct => ct.Id == id);
        if (competence != null)
        {
          var competenceDto = _mapper.Map<Competence, CompetenceDto>(competence);
          return competenceDto;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
      return null;
    }

    public async Task<CompetenceDto> AddCompetenceAsync(CompetenceDto competenceDto)
    {
      try
      {
        var competence = _mapper.Map<CompetenceDto, Competence>(competenceDto);

        await _appDbContext.Competences.AddAsync(competence);
        await _appDbContext.SaveChangesAsync();

        var newCompetenceDto =
          _mapper.Map<Competence, CompetenceDto>(
            await _appDbContext.Competences.FirstOrDefaultAsync(ct => ct.Id == competence.Id));

        return newCompetenceDto;

      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<CompetenceDto> EditCompetenceAsync(int id, CompetenceDto competenceDto)
    {
      try
      {
        var competenceForEdit = await _appDbContext.Competences.FirstOrDefaultAsync(ct => ct.Id == id);
        if (competenceForEdit != null)
        {
          competenceForEdit.Name = competenceDto.Name;
          _appDbContext.Competences.Update(competenceForEdit);

          await _appDbContext.SaveChangesAsync();
          var newCompetence = _mapper.Map<Competence, CompetenceDto>(competenceForEdit);

          return newCompetence;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

      return null;
    }

    public async Task<bool> DeleteCompetenceAsync(int id)
    {
      try
      {
        var competence = await _appDbContext.Competences.FirstOrDefaultAsync(ct => ct.Id == id);
        if (competence != null)
        {
          _appDbContext.Competences.Remove(competence);
          await _appDbContext.SaveChangesAsync();
          return true;
        }
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
      return false;
    }
  }
}
