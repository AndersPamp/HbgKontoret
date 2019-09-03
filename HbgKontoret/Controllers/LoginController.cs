  using HbgKontoret.Data.Entities;
  using HbgKontoret.Infrastructure.Interfaces;
  using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HbgKontoret.Controllers
{
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    private ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
      _loginService = loginService;
    }

    //[AllowAnonymous]
    //[HttpPost("authenticate")]
    //public IActionResult Authenticate([FromBody] Login loginParam)
    //{
    //  var user = _loginService.Authenticate(loginParam.Username, loginParam.Password);
    //  if (user == null)
    //    return BadRequest(new {message = "Username and/or password is incorrect"});

    //  return Ok(user);
    //}

    [AllowAnonymous]
    [HttpPost(template: "register")]
    public IActionResult Register([FromBody] Login loginParam)
    {
      var user = _loginService.RegisterUser(loginParam.Username, loginParam.Password);
      return Ok(user);
    }

    //[HttpGet]
    //public IActionResult GetAll()
    //{
    //  Login.
    //  var users = _loginService.GetAll();
    //  return Ok(users);
    //}
  }
}