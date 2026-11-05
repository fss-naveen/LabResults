using LabResults.Models;

namespace LabResults.Services;

public interface ILabResultService
{
    LabResult Create(LabResult result);
    LabResult? GetById(int id);
    IReadOnlyList<LabResult> GetByPatientId(string patientId);
    bool Update(int id, LabResult result);
    bool Delete(int id);
}