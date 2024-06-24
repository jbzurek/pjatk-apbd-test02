using Microsoft.EntityFrameworkCore;
using test02.Context;
using test02.Models;

namespace test02.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly Test02Context _context;

    public PatientRepository(Test02Context context)
    {
        _context = context;
    }

    public async Task<Patient?> GetPatientWithVisitsAsync(int idPatient)
    {
        return await _context.Patients
            .Include(p => p.Visits)
            .ThenInclude(v => v.IdDoctorNavigation)
            .FirstOrDefaultAsync(p => p.IdPatient == idPatient);
    }
}