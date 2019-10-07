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
  //[Authorize]
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
    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(Guid id)
    {
      try
      {
        return Ok(await _userService.GetUserByIdAsync(id));
      }
      catch (Exception e)
      {
        return NotFound(new JsonResponse
        {
          Error = true,
          Message = e.Message.ToString()
        });
      }
      
    }
    #endregion

    //POST: api/user/authenticate
    [AllowAnonymous]
    [HttpPost("authenticate")]
    //[ValidateAntiForgeryToken]
    public IActionResult Authenticate([FromBody] UserDto userParam)
    {
      var token = _userService.Authenticate(userParam.Email, userParam.Password);

      //Set token in access_token cookie and also set a CSRF token

      if (token == null)
      {
        return BadRequest(new JsonResponse
        {
          Error = true,
          Message = "Username and/or password is incorrect.  All makt åt Tengil, vår befriare!"
        });
      }
      return Ok(token);
    }

    //POST: api/user/register
    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register([FromBody] UserDto userDto)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var result = _userService.AddUserAsync(userDto.Email, userDto.Password).Result;
          if (result!=null)
          {
            return Created("", new JsonResponse
            {
              Data = result
            });
          }
        }
        catch (Exception e)
        {
          return BadRequest(new JsonResponse
          {
            Error = true,
            Message = new Exception(e.Message).ToString()
          });
        }
      }
      else if (!ModelState.IsValid)
      {
        return BadRequest(new JsonResponse
        {
          Error = true,
          Message = "Username and/or password was not supplied, numbnuts!"
        });
      }

      return BadRequest(new JsonResponse
      {
        Error = true
      });
    }


    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    
    public async Task<ActionResult> Delete(Guid id)
    {
      try
      {
        var result = await _userService.DeleteUserAsync(id);
        return NoContent();
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
