namespace test02.Models;

public class Visit
{
    public int IdVisit { get; set; }
    public DateTime Date { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    public decimal Price { get; set; }
    public virtual Doctor IdDoctorNavigation { get; set; } = null!;
    public virtual Patient IdPatientNavigation { get; set; } = null!;
}