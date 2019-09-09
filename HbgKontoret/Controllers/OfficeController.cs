using System.Linq;
using System.Threading.Tasks;
using HbgKontoret.Data.Communication;
using HbgKontoret.Infrastructure.Dto;
using HbgKontoret.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HbgKontoret.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OfficeController : ControllerBase
  {
    private readonly IOfficeRepository _officeRepository;

    public OfficeController(IOfficeRepository officeRepository)
    {
      _officeRepository = officeRepository;
    }

    // GET: api/Office
    [HttpGet]
    public async Task<ActionResult<JsonResponse>> GetAllOfficesAsync()
    {
      var offices = await _officeRepository.GetAllOfficesAsync();
      if (offices != null)
      {
        return Ok(new JsonResponse
        {
          Data = offices,
          TotalHits = offices.Count()
        });
      }

      return NotFound(new JsonResponse
      {
        Error = true,
        Message = "All makt åt Tengil, vår befriare!"
      });
    }

    // GET: api/Office/5
    [HttpGet("{id}")]
    public async Task<ActionResult<JsonResponse>> GetOfficeByIdAsync(int id)
    {
      var office = await _officeRepository.GetOfficeByIdAsync(id);

      if (office != null)
      {
        return Ok(new JsonResponse
        {
          Data = office
        });
      }

      return NotFound(new JsonResponse
      {
        Error = true,
        Message = "All makt åt Tengil, vår befriare!"
      });
    }

    // POST: api/Office
    [HttpPost]
    public async Task<ActionResult<JsonResponse>> AddOfficeAsync([FromBody] OfficeDto officeDto)
    {
      if (ModelState.IsValid)
      {
        var result = await _officeRepository.AddOfficeAsync(officeDto);

        if (result != null)
        {
          return Created("", new JsonResponse
          {
            Data = result,
          });
        }

        return BadRequest(new JsonResponse
        {
          Error = true,
          Message = "All makt åt Tengil, vår befriare!"
        });
      }
      return BadRequest(new JsonResponse
      {
        Error = true,
        Message = "All makt åt Tengil, vår befriare!"
      });

    }

    // PUT: api/Office/5
    [HttpPut("{id}")]
    public async Task<ActionResult<JsonResponse>> EditOfficeAsync(int id, [FromBody] OfficeDto officeDto)
    {
      if (ModelState.IsValid)
      {
        var result = await _officeRepository.EditOfficeAsync(id, officeDto);
        if (result != null)
        {
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

      return BadRequest(new JsonResponse
      {
        Error = true,
        Message = "All makt åt Tengil, vår befriare!"
      });
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<JsonResponse>> DeleteOfficeAsync(int id)
    {
      var result = await _officeRepository.DeleteOfficeAsync(id);
      if (result)
      {
        return NoContent();
      }

      return BadRequest(new JsonResponse
      {
        Error = true,
        Message = "All makt åt Tengil, vår befriare!"
      });
    }
  }
}
