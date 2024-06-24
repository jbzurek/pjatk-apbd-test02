using Microsoft.EntityFrameworkCore;
using test02.Context;
using test02.Models;

namespace test02.Repositories;

public class VisitRepository : IVisitRepository
{
    private readonly Test02Context _context;

    public VisitRepository(Test02Context context)
    {
        _context = context;
    }

    public async Task<bool> PatientExistsAsync(int idPatient)
    {
        return await _context.Patients.AnyAsync(p => p.IdPatient == idPatient);
    }

    public async Task<bool> DoctorExistsAsync(int idDoctor)
    {
        return await _context.Doctors.AnyAsync(d => d.IdDoctor == idDoctor);
    }

    public async Task<bool> HasScheduleConflictAsync(int idDoctor, DateTime date)
    {
        return await _context.Visits.AnyAsync(v => v.IdDoctor == idDoctor && v.Date == date);
    }

    public async Task<int> GetDoctorVisitCountAsync(int idDoctor, DateTime date)
    {
        return await _context.Visits.CountAsync(v => v.IdDoctor == idDoctor && v.Date.Date == date.Date);
    }

    public async Task<int> GetPatientVisitCountAsync(int idPatient)
    {
        return await _context.Visits.CountAsync(v => v.IdPatient == idPatient);
    }

    public async Task<decimal> GetDoctorVisitPriceAsync(int idDoctor)
    {
        return await _context.Doctors.Where(d => d.IdDoctor == idDoctor).Select(d => d.PriceForVisit).FirstOrDefaultAsync();
    }

    public async Task AddVisitAsync(Visit visit)
    {
        _context.Visits.Add(visit);
        await _context.SaveChangesAsync();
    }
}