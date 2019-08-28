using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HbgKontoret.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
      
    }
}