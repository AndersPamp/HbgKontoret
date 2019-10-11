using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace HbgKontoret.Controllers
{
  public abstract class BaseController : ControllerBase
  {
    protected string GetUserId()
    {
      var result = this.User.Claims.FirstOrDefault(x => x.Type == "Id").Value;

      if (result != null)
      {
        return result;
      }

      return null;
    }
  }
}