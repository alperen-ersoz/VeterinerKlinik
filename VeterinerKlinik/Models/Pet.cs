using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinerKlinik.Models;

public class Pet
{
    public int Id { get; set; }

    [Required]
    public string OwnerId { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Species { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Breed { get; set; } = string.Empty;

    public DateOnly BirthDate { get; set; }

    [Range(0.01, 1000)]
    [Column(TypeName = "decimal(8,2)")]
    public decimal Weight { get; set; }

    [StringLength(500)]
    public string? PhotoPath { get; set; }

    public bool IsActive { get; set; } = true;

    public ApplicationUser Owner { get; set; } = null!;
}