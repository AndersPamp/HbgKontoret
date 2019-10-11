using System;
using System.Linq;
using System.Threading.Tasks;
using HbgKontoret.Data.Communication;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace HbgKontoret.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class ProfileController : ControllerBase
  {
    private readonly IProfileService _profileService;
    private readonly IUserService _userService;

    public ProfileController(IProfileService profileService, IUserService userService)
    {
      _profileService = profileService;
      _userService = userService;
    }

    // GET: api/ProfileDto
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<JsonResponse>> GetAllProfileDtos()
    {
      var profileDtos = await _profileService.GetAllProfileAsync();
      if (profileDtos != null)
      {
        return Ok(new JsonResponse
        {
          Data = profileDtos,
          TotalHits = profileDtos.Count()
        });
      }

      return NotFound(new JsonResponse
      {
        Error = true,
        Message = "All makt åt Tengil, vår befriare!"
      });
    }

    // GET: api/ProfileDto/5
    [HttpGet("profile")]
    [AllowAnonymous]
    public async Task<ActionResult<JsonResponse>> GetProfileDtoById()
    {
      var userId= User.Identity.Name;

      try
      {
        var user = await _userService.GetUserByIdAsync(Guid.Parse(userId));
        var profileDto = user.ProfileDtoId.HasValue ? await _profileService.GetProfileByIdAsync(user.ProfileDtoId.Value) : null;

        if (profileDto != null)
        {
          return Ok(new JsonResponse
          {
            Data = profileDto
          });
        }

        return NotFound(new JsonResponse
        {
          Error = true,
          Message = "No profile found for this user"
        });
      }
      catch (Exception e)
      {
        return NotFound(new JsonResponse
        {
          Error = true,
          Message = e.Message
        });
      }
    }

    // POST: api/ProfileDto
    [HttpPost("register")]
    public async Task<ActionResult<JsonResponse>> AddProfileDto([FromBody] ProfileDto profileDto)
    {
      var userId = User.Identity.Name;
      var user = await _userService.GetUserByIdAsync(Guid.Parse(userId));


      if (ModelState.IsValid)
      {
        var newProfileDto = await _profileService.AddProfileAsync(profileDto.FirstName, profileDto.LastName, profileDto.Manager, profileDto.ImageUrl, profileDto.LinkedInUrl,
          profileDto.PhoneNo, profileDto.AboutMe);
        user.ProfileDtoId = newProfileDto.Id;
        await _userService.UpdateUserByIdAsync(Guid.Parse(userId), user);
        return Created("", new JsonResponse
        {
          Data = newProfileDto
        });
      }

      return BadRequest(new JsonResponse
      {
        Error = true,
        Message = "All makt åt Tengil, vår befriare!"
      });
    }

    // PUT: api/ProfileDto/5
    [HttpPut]
    public async Task<ActionResult<ProfileDto>> EditProfileDto([FromBody] ProfileDto profileDto)
    {
      var userId = User.Identity.Name;

      try
      {
        var user = await _userService.GetUserByIdAsync(Guid.Parse(userId));
        

        if (user.ProfileDtoId.HasValue)
        {
          var profile = await _profileService.GetProfileByIdAsync(user.ProfileDtoId.Value);
          var result = await _profileService.EditProfileAsync(profile.Id, profileDto);
          await _userService.UpdateUserByIdAsync(Guid.Parse(userId), user);
          return Created("", new JsonResponse
          {
            Data = result
          });
        }

        return Created("", await AddProfileDto(profileDto));
      }
      catch (Exception e)
      {

        return BadRequest(new JsonResponse
        {
          Error = true,
          Message = e.Message
        });
      }
    }

    //PATCH: api/ProfileDto/5
    [HttpPatch("edit/{id}")]
    public async Task<ActionResult<ProfileDto>> PatchProfile(Guid id, [FromBody]JsonPatchDocument<ProfileDto> value)
    {
      if (value == null)
      {
        return BadRequest(new JsonResponse
        {
          Error = true,
          Message = "You haven't submitted any data to edit the profile with."
        });
      }

      try
      {
        var profile = await _profileService.GetProfileByIdAsync(id);

        if (profile != null)
        {
          value.ApplyTo(profile);

          return Ok(new JsonResponse
          {
            Data = profile
          });
        }
      }
      catch (Exception e)
      {
        return BadRequest(new JsonResponse
        {
          Error = true,
          Message = e.ToString()
        });
      }

      return BadRequest();
    }

    // DELETE: api/ApiWithActions/5

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProfileDto(Guid id)
    {
      if (await _profileService.GetProfileByIdAsync(id) != null)
      {
        if (await _profileService.DeleteProfileAsync(id))
        {
          return Ok();
        }

        return NotFound("All makt åt Tengil, vår befriare!");
      }

      return NotFound("All makt åt Tengil, vår befriare!");
    }
  }
}
