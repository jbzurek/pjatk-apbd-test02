namespace test02.DTOs;

public class PatientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public decimal TotalAmountMoneySpent { get; set; }
    public int NumberOfVisit { get; set; }
    public List<VisitDto> Visits { get; set; }
}