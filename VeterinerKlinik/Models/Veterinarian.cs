using System.ComponentModel.DataAnnotations;

namespace VeterinerKlinik.Models;

public class Veterinarian
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Specialty { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Biography { get; set; }

    public bool IsActive { get; set; } = true;

    public ApplicationUser User { get; set; } = null!;
}