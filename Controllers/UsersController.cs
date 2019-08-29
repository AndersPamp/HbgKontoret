using HbgKontoret.Data.Entities;
using HbgKontoret.Data.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HbgKontoret.Controllers
{
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] User userParam)
    {
      var user = _userService.Authenticate(userParam.Username, userParam.Password);
      if (user == null)
        return BadRequest(new {message = "Username and/or password is incorrect"});

      return Ok(user);
    }

    [AllowAnonymous]
    [HttpPost(template: "register")]
    public IActionResult Register([FromBody] User userParam)
    {
      var user = _userService.RegisterUser(userParam.Username, userParam.Password);
      return Ok(user);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      var users = _userService.GetAll();
      return Ok(users);
    }
  }
}