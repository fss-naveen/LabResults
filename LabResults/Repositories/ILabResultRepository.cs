using LabResults.Models;

namespace LabResults.Repositories;

public interface ILabResultRepository
{
    LabResult Add(LabResult result);
    LabResult? GetById(int id);
    IReadOnlyList<LabResult> GetByPatientId(string patientId);
    bool Update(LabResult result);
    bool Delete(int id);
}