using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinerKlinik.Models;

public class Service
{
    public int Id { get; set; }

    public int ClinicId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [Range(1, 1440)]
    public int DurationMinutes { get; set; }

    [Range(0, 1000000)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public bool IsActive { get; set; } = true;

    public Clinic Clinic { get; set; } = null!;
}