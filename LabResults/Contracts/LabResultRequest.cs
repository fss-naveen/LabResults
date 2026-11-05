using System.ComponentModel.DataAnnotations;

namespace LabResults.Contracts;

public class LabResultRequest
{
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string PatientId { get; set; } = string.Empty;

    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string TestName { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string ResultValue { get; set; } = string.Empty;

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Unit { get; set; } = string.Empty;

    [Required]
    public DateTime? ObservedDate { get; set; }
}
