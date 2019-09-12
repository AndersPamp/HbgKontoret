using System.Threading.Tasks;
using HbgKontoret.Data.Communication;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HbgKontoret.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class ProfileOfficeController : ControllerBase
  {
    private readonly IProfileRepository _profileRepository;

    public ProfileOfficeController(IProfileRepository profileRepository)
    {
      _profileRepository = profileRepository;
    }

    // POST: api/ProfileOffice
    
    [HttpPost]
    public async Task<ActionResult<JsonResponse>> Post([FromBody] ProfileOfficeDto profileOfficeDto)
    {
      if (ModelState.IsValid)
      {
        var result = await _profileRepository.AddProfileOfficeAsync(profileOfficeDto);
        return Created("", new JsonResponse
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


    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(ProfileOfficeDto profileOfficeDto)
    {
      var result = await _profileRepository.DeleteProfileOfficeAsync(profileOfficeDto);

      if (result)
      {
        return NoContent();
      }

      return BadRequest(new JsonResponse
      {
        Error = true,
        Message = "All makt åt Tengil, vår befriare!"
      });

    }
  }
}
