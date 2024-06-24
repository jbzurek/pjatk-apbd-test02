namespace test02.Services;

public interface IVisitService
{
    Task<int?> AddVisitAsync(int idPatient, int idDoctor, DateTime date);
}