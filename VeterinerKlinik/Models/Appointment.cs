using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinerKlinik.Models;

public class Appointment
{
    public int Id { get; set; }

    public int PetId { get; set; }

    public int VeterinarianId { get; set; }

    public int ServiceId { get; set; }

    public DateTime StartDateTime { get; set; }

    [Range(1, 1440)]
    public int DurationMinutes { get; set; }

    [Range(0, 1000000)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public AppointmentStatus Status { get; set; }
        = AppointmentStatus.Pending;

    [StringLength(4000)]
    public string? ExaminationNote { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Pet Pet { get; set; } = null!;

    public Veterinarian Veterinarian { get; set; } = null!;

    public Service Service { get; set; } = null!;
}