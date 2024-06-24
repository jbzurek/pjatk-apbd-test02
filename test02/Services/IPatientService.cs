using test02.DTOs;

namespace test02.Services;

public interface IPatientService
{
    Task<PatientDto?> GetPatientWithVisitsAsync(int idPatient);
}