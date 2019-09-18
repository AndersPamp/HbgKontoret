﻿using System;
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

    public ProfileController(IProfileService profileService)
    {
      _profileService = profileService;
    }

    // GET: api/ProfileDto
    [HttpGet]
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
    [HttpGet("{id}")]
    public async Task<ActionResult<JsonResponse>> GetProfileDtoById(Guid id)
    {
      var profileDto = await _profileService.GetProfileByIdAsync(id);

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
        Message = "All makt åt Tengil, vår befriare!"
      });
    }

    // POST: api/ProfileDto
    [HttpPost("register")]
    public async Task<ActionResult<JsonResponse>> AddProfileDto([FromBody] ProfileDto ProfileDto)
    {
      if (ModelState.IsValid)
      {
        var newProfileDto = await _profileService.AddProfileAsync(ProfileDto.Manager, ProfileDto.ImageUrl, ProfileDto.LinkedInUrl,
          ProfileDto.PhoneNo, ProfileDto.AboutMe);

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
    [HttpPut("{id}")]
    public async Task<ActionResult<ProfileDto>> EditProfileDto(Guid id, [FromBody] ProfileDto profileDto)
    {
      if (ModelState.IsValid)
      {
        var result = await _profileService.EditProfileAsync(id, profileDto);
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

    //PATCH: api/ProfileDto/5
    [HttpPatch("edit/{id}")]
    public async Task<ActionResult<ProfileDto>> PatchProfile(Guid id, [FromBody]JsonPatchDocument<ProfileDto> value)
    {
      if (value==null)
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
