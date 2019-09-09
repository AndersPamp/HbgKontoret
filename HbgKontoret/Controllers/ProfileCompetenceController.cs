using System.Threading.Tasks;
using HbgKontoret.Data.Communication;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HbgKontoret.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProfileCompetenceController : ControllerBase
  {
    private readonly IProfileRepository _profileRepository;

    public ProfileCompetenceController(IProfileRepository profileRepository)
    {
      _profileRepository = profileRepository;
    }

    // POST: api/ProfileCompetence
    [HttpPost]
    public async Task<ActionResult<JsonResponse>> Post([FromBody] ProfileCompetenceDto profileCompetenceDto)
    {
      if (ModelState.IsValid)
      {
        var result = await _profileRepository.AddProfileCompetenceAsync(profileCompetenceDto);
        return Created("", new JsonResponse
        {
          Data = result,
          Message = "Ok"
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
    public async Task<ActionResult<JsonResponse>> Delete(ProfileCompetenceDto profileCompetenceDto)
    {
      var result = await _profileRepository.DeleteProfileCompetenceAsync(profileCompetenceDto);
      if (result)
      {
        return NoContent();
      }

      return BadRequest();
    }
  }
}
