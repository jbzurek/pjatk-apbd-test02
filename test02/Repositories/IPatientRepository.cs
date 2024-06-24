using test02.Models;

namespace test02.Repositories;

public interface IPatientRepository
{
    Task<Patient?> GetPatientWithVisitsAsync(int idPatient);
}