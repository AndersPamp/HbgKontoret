using System.Linq;
using System.Threading.Tasks;
using HbgKontoret.Data.Communication;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HbgKontoret.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CompetenceController : ControllerBase
  {
    private readonly ICompetenceRepository _competenceRepository;

    public CompetenceController(ICompetenceRepository competenceRepository)
    {
      _competenceRepository = competenceRepository;
    }

    // GET: api/Competence
    [HttpGet]
    public async Task<ActionResult<JsonResponse>> GetAllCompetencesAsync()
    {
      var competences = await _competenceRepository.GetAllCompetencesAsync();
      if (competences != null)
      {
        return Ok(new JsonResponse
        {
          Data = competences,
          TotalHits = competences.Count()
        });
      }

      return NotFound(new JsonResponse
      {
        Error = true,
        Message = "All makt åt Tengil, vår befriare!"
      });
    }

    // GET: api/Competence/5
    [HttpGet("{id}")]
    public async Task<ActionResult<JsonResponse>> GetCompetenceById(int id)
    {
      var competence = await _competenceRepository.GetCompetenceByIdAsync(id);
      if (competence != null)
      {
        return Ok(new JsonResponse
        {
          Data = competence

        });
      }

      return NotFound(new JsonResponse
      {
        Error = true,
        Message = "All makt åt Tengil, vår befriare!"
      });
    }

    // POST: api/Competence
    [HttpPost]
    public async Task<ActionResult<JsonResponse>> AddCompetenceAsync([FromBody] CompetenceDto competenceDto)
    {
      if (ModelState.IsValid)
      {
        var competence = await _competenceRepository.AddCompetenceAsync(competenceDto);
        return Created("", new JsonResponse
        {
          Data = competence
        });
      }

      return BadRequest(new JsonResponse
      {
        Error = true,
        Message = "All makt åt Tengil, vår befriare!"
      });
    }

    // PUT: api/Competence/5
    [HttpPut("{id}")]
    public async Task<ActionResult<JsonResponse>> EditCompetenceAsync(int id, [FromBody] CompetenceDto competenceDto)
    {
      if (ModelState.IsValid)
      {
        var result = await _competenceRepository.EditCompetenceAsync(id, competenceDto);

        if (result != null)
        {
          return Ok(new JsonResponse
          {
            Data = result
          });
        }

        return BadRequest(new JsonResponse
        {
          Error = true,
          Message = "All makt åt Tengil, vår befriare!"
        });
      }
      return BadRequest(new JsonResponse
      {
        Error = true,
        Message = "All makt åt Tengil, vår befriare!"
      });
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<JsonResponse>> DeleteCompetenceAsync(int id)
    {
      var result = await _competenceRepository.DeleteCompetenceAsync(id);
      if (result)
      {
        NoContent();
      }

      return BadRequest(new JsonResponse
      {
        Error = true,
        Message = "All makt åt Tengil, vår befriare!"
      });
    }
  }
}
