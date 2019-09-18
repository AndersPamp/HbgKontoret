using System;
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

        try
        {
          var result = await _profileRepository.AddProfileOfficeAsync(profileOfficeDto);
          return Created("", new JsonResponse
          {
            Data = result
          });
        }
        catch (Exception e)
        {
          return BadRequest(new JsonResponse
          {
            Error = true,
            Message = e.Message.ToString()
          });
        }

      return BadRequest(new JsonResponse
      {
        Error = true,
        Message = "It seems that not all parameters were submitted."
      });
    }


    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(ProfileOfficeDto profileOfficeDto)
    {
      try
      {
        var result = await _profileRepository.DeleteProfileOfficeAsync(profileOfficeDto);

        if (result)
        {
          return NoContent();
        }
        return BadRequest();

      }
      catch (Exception e)
      {
        return BadRequest(new JsonResponse
        {
          Error = true,
          Message = e.Message.ToString()
        });
      }
    }
  }
}
