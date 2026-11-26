using System.ComponentModel.DataAnnotations;

namespace VeterinerKlinik.Models;

public class VaccinationRecord
{
    public int Id { get; set; }

    public int PetId { get; set; }

    [Required]
    [StringLength(100)]
    public string VaccineName { get; set; } = string.Empty;

    public DateOnly VaccinationDate { get; set; }

    public DateOnly? NextDoseDate { get; set; }

    public Pet Pet { get; set; } = null!;
}