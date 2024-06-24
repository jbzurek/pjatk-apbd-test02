using Microsoft.AspNetCore.Mvc;
using test02.DTOs;
using test02.Services;

namespace test02.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VisitsController : ControllerBase
{
    private readonly IVisitService _visitService;

    public VisitsController(IVisitService visitService)
    {
        _visitService = visitService;
    }

    [HttpPost]
    public async Task<IActionResult> AddVisitAsync([FromBody] NewVisitDto visitDto)
    {
        try
        {
            var visitId = await _visitService.AddVisitAsync(visitDto.IdPatient, visitDto.IdDoctor, visitDto.Date);

            if (visitId == null)
            {
                return BadRequest("Could not schedule visit!");
            }

            return Ok(visitId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}