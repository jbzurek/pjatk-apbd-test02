using test02.Models;
using test02.Repositories;

namespace test02.Services;

public class VisitService : IVisitService
{
    private readonly IVisitRepository _visitRepository;

    public VisitService(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }

    public async Task<int?> AddVisitAsync(int idPatient, int idDoctor, DateTime date)
    {
        if (!await _visitRepository.PatientExistsAsync(idPatient) ||
            !await _visitRepository.DoctorExistsAsync(idDoctor))
        {
            return null;
        }

        if (await _visitRepository.HasScheduleConflictAsync(idDoctor, date))
        {
            return null;
        }

        if (await _visitRepository.GetDoctorVisitCountAsync(idDoctor, date) >= 5)
        {
            return null;
        }

        var patientVisitCount = await _visitRepository.GetPatientVisitCountAsync(idPatient);
        var doctorVisitPrice = await _visitRepository.GetDoctorVisitPriceAsync(idDoctor);
        var price = patientVisitCount > 10 ? doctorVisitPrice * 0.9m : doctorVisitPrice;

        var visit = new Visit
        {
            IdPatient = idPatient,
            IdDoctor = idDoctor,
            Date = date,
            Price = price
        };

        await _visitRepository.AddVisitAsync(visit);
        return visit.IdVisit;
    }
}