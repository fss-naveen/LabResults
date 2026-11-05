namespace LabResults.Models;

public class LabResult
{
    public int Id { get; set; }
    public string PatientId { get; set; } = string.Empty;
    public string TestName { get; set; } = string.Empty;
    public string ResultValue { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public DateTime ObservedDate { get; set; }
}