using System.Collections.Concurrent;
using LabResults.Models;

namespace LabResults.Repositories;

public class InMemoryLabResultRepository : ILabResultRepository
{
    private readonly ConcurrentDictionary<int, LabResult> _results = new();
    private int _nextId;

    public LabResult Add(LabResult result)
    {
        var id = Interlocked.Increment(ref _nextId);
        var savedResult = new LabResult
        {
            Id = id,
            PatientId = result.PatientId,
            TestName = result.TestName,
            ResultValue = result.ResultValue,
            Unit = result.Unit,
            ObservedDate = result.ObservedDate
        };

        _results[id] = savedResult;
        return savedResult;
    }

    public LabResult? GetById(int id)
    {
        return _results.TryGetValue(id, out var result) ? result : null;
    }

    public IReadOnlyList<LabResult> GetByPatientId(string patientId)
    {
        return _results.Values
            .Where(result => result.PatientId.Equals(patientId, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(result => result.ObservedDate)
            .ToList();
    }

    public bool Update(LabResult result)
    {
        if (!_results.ContainsKey(result.Id))
        {
            return false;
        }

        _results[result.Id] = result;
        return true;
    }

    public bool Delete(int id)
    {
        return _results.TryRemove(id, out _);
    }
}