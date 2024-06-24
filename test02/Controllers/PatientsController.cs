using Microsoft.AspNetCore.Mvc;
using test02.Services;

namespace test02.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{idPatient}")]
    public async Task<IActionResult> GetPatientWithVisitsAsync(int idPatient)
    {
        var patient = await _patientService.GetPatientWithVisitsAsync(idPatient);
        
        if (patient == null)
        {
            return NotFound();
        }

        return Ok(patient);
    }
}