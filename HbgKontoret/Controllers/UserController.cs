using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HbgKontoret.Data.Communication;
using HbgKontoret.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using HbgKontoret.Infrastructure.Interfaces;
using HbgKontoret.Infrastructure.Dto;
using Microsoft.AspNetCore.Authorization;

namespace HbgKontoret.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }
    // GET: api/User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
      return Ok(await _userService.GetAllUsersAsync());
    }

    #region obsolete
    //// GET: api/User/5
    //[HttpGet("{id}")]
    //public async Task<ActionResult<User>> GetUserById(Guid id)
    //{

    //  return Ok(await _userService.GetUserByIdAsync(id));
    //} 
    #endregion

    [HttpPost]
    [Authorize]
    public IActionResult IsAuthenticated()
    {
      return Ok("Authenticated");
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Athenticate([FromBody] UserDto userParam)
    {
      var userDto = _userService.Authenticate(userParam.Email, userParam.Password);

      //Set token in access_token cookie and also set a CSRF token

      if (userDto==null)
      {
        return BadRequest(new JsonResponse
        {
          Error = true,
          Message = "Username and/or password is incorrect.  All makt åt Tengil, vår befriare!"
        });
      }

      return Ok(new JsonResponse
      {
        Data = userDto
      });
    }

    // POST: api/User
    [HttpPost]
    public async Task<ActionResult<UserDto>> AddUser([FromBody]UserDto userDto)

    {
      if (ModelState.IsValid)
      {
        var newUserDto = await _userService.AddUserAsync(userDto.Email, userDto.Password);
        return Created("", new JsonResponse
        {
          Data = newUserDto
        });
      }

      return BadRequest(new JsonResponse
      {
        Error = true,
        Message = "Not all required parameters were submitted"
      });
    }

    //// PUT: api/User/5
    //[HttpPut("{id}")]
    //public async Task<ActionResult<User>> EditUser(Guid id, [FromBody] User user)
    //{
    //  if (ModelState.IsValid)
    //  {
    //    var editedUser =
    //    await _userService.EditUserAsync(id, user.FirstName, user.LastName, user.Email);
    //    return Accepted(editedUser);
    //  }

    //  return BadRequest("Not all required parameters were submitted");
    //}

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
      var result = await _userService.DeleteUserAsync(id);

      if (result)
      {
        return NoContent();
      }

      return BadRequest("Something went wrong");
    }
  }
}
