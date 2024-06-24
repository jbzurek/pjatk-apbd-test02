using test02.Models;

namespace test02.Repositories;

public interface IVisitRepository
{
    Task<bool> PatientExistsAsync(int patientId);
    Task<bool> DoctorExistsAsync(int doctorId);
    Task<bool> HasScheduleConflictAsync(int doctorId, DateTime date);
    Task<int> GetDoctorVisitCountAsync(int doctorId, DateTime date);
    Task<int> GetPatientVisitCountAsync(int patientId);
    Task<decimal> GetDoctorVisitPriceAsync(int doctorId);
    Task AddVisitAsync(Visit visit);
}