using Microsoft.EntityFrameworkCore;
using test02.Models;

namespace test02.Context;

public partial class Test02Context : DbContext
{
    public Test02Context()
    {
    }

    public Test02Context(DbContextOptions<Test02Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=test02;Integrated Security=True;trusted_connection=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("Doctor_pk");

            entity.ToTable("Doctor");

            entity.Property(e => e.IdDoctor).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PriceForVisit).HasColumnType("money");
            entity.Property(e => e.Specialization).HasMaxLength(100);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.IdPatient).HasName("Patient_pk");

            entity.ToTable("Patient");

            entity.Property(e => e.IdPatient).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.IdSchedule).HasName("Schedule_pk");

            entity.ToTable("Schedule");

            entity.Property(e => e.IdSchedule).ValueGeneratedNever();
            entity.Property(e => e.DateFrom).HasColumnType("datetime");
            entity.Property(e => e.DateTo).HasColumnType("datetime");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Schedule_Doctor");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.IdVisit).HasName("Visit_pk");

            entity.ToTable("Visit");

            entity.Property(e => e.IdVisit).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Visits)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Table_6_Doctor");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.Visits)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Table_6_Patient");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}