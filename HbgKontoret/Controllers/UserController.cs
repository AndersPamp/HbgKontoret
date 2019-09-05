using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HbgKontoret.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HbgKontoret.Infrastructure.Interfaces;
using HbgKontoret.Infrastructure.Dto;

namespace HbgKontoret.Controllers
{
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

    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(Guid id)
    {

      return Ok(await _userService.GetUserByIdAsync(id));
    }

    // POST: api/User
    [HttpPost]
    public async Task<ActionResult<UserDto>> AddUser([FromBody]UserDto userDto)

    {
      if (ModelState.IsValid)
      {
        var newUser = await _userService.AddUserAsync(userDto.FirstName, userDto.LastName, userDto.Email);
        return Created("", newUser);
      }

      return BadRequest("Not all required parameters were submitted");
    }


    // PUT: api/User/5
    [HttpPut("{id}")]
    public async Task<ActionResult<User>> EditUser(Guid id, [FromBody] User user)
    {
      if (ModelState.IsValid)
      {
        var editedUser =
          await _userService.EditUserAsync(id, user.FirstName, user.LastName, user.Email);
        return Accepted(editedUser);
      }

      return BadRequest("Not all required parameters were submitted");
    }

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
