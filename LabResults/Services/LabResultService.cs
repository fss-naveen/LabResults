using LabResults.Models;
using LabResults.Repositories;

namespace LabResults.Services;

public class LabResultService : ILabResultService
{
    private readonly ILabResultRepository _repository;

    public LabResultService(ILabResultRepository repository)
    {
        _repository = repository;
    }

    public LabResult Create(LabResult result)
    {
        return _repository.Add(result);
    }

    public LabResult? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public IReadOnlyList<LabResult> GetByPatientId(string patientId)
    {
        return _repository.GetByPatientId(patientId);
    }

    public bool Update(int id, LabResult result)
    {
        result.Id = id;
        return _repository.Update(result);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}