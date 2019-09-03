using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using HbgKontoret.Data.Entities;
using HbgKontoret.Data.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HbgKontoret.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProfileController : ControllerBase
  {
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
      _profileService = profileService;
    }

    // GET: api/Profile
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Profile>>> GetAllProfiles()
    {
      return Ok(await _profileService.GetAllProfileAsync());
    }

    // GET: api/Profile/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Profile>> GetProfileById(Guid id)
    {
      var profile = await _profileService.GetProfileByIdAsync(id);

      if (profile != null)
      {
        return Ok(profile);
      }

      return NotFound("No profile with that id found");
    }

    // POST: api/Profile
    [HttpPost]
    public async Task<ActionResult<Profile>> AddProfile([FromBody] Profile profile)
    {
      if (ModelState.IsValid)
      {
        var newProfile = await _profileService.AddProfileAsync(profile.Manager, profile.ImageUrl, profile.LinkedInUrl,
          profile.PhoneNo, profile.AboutMe);

        return Created("", newProfile);
      }

      return BadRequest("All makt åt Tengil, vår befriare!");
    }

    // PUT: api/Profile/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Profile>> EditProfile(Guid id, [FromBody] Profile profile)
    {
      if (await _profileService.GetProfileByIdAsync(id) != null)
      {
        await _profileService.EditProfileAsync(id, profile.Manager, profile.ImageUrl, profile.LinkedInUrl,
          profile.PhoneNo, profile.AboutMe);

        return Ok(profile);
      }

      return NotFound();

    }

    ////PATCH: api/profile/5
    //[HttpPatch("{id}")]
    //public async Task<ActionResult<Profile>> EditProfile(Guid id, [FromBody]JsonPatchDocument<Profile> value)
    //{
    //  var result = await _profileService.GetProfileByIdAsync(id);
    //  if (result!=null)
    //  {
    //   value.ApplyTo(result, ModelState);


    //    return Created("",result);
    //  }

    //  return BadRequest();
    //}

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProfile(Guid id)
    {
      if (await _profileService.GetProfileByIdAsync(id)!=null)
      {
        if (await _profileService.DeleteProfileAsync(id))
        {
          return Ok();
        }

        return NotFound();
      }

      return NotFound();
    }
  }
}
