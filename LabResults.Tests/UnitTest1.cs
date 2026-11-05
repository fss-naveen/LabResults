using LabResults.Models;
using LabResults.Repositories;
using LabResults.Services;

namespace LabResults.Tests;

public class LabResultServiceTests
{
    [Fact]
    public void Create_AssignsIdAndStoresResult()
    {
        // Arrange: create the in-memory repository and service.
        var repository = new InMemoryLabResultRepository();
        var service = new LabResultService(repository);

        var result = new LabResult
        {
            PatientId = "PAT-001",
            TestName = "Hemoglobin",
            ResultValue = "13.5",
            Unit = "g/dL",
            ObservedDate = new DateTime(2026, 11, 5)
        };

        // Act: ask the service to create the result.
        var created = service.Create(result);

        // Assert: it received an ID and can be retrieved.
        Assert.True(created.Id > 0);
        Assert.Equal("PAT-001", service.GetById(created.Id)!.PatientId);
    }

    [Fact]
    public void GetByPatientId_ReturnsOnlyMatchingPatientResults()
    {
        var repository = new InMemoryLabResultRepository();
        var service = new LabResultService(repository);

        service.Create(new LabResult
        {
            PatientId = "PAT-001",
            TestName = "Hemoglobin",
            ResultValue = "13.5",
            Unit = "g/dL",
            ObservedDate = new DateTime(2026, 11, 5)
        });

        service.Create(new LabResult
        {
            PatientId = "PAT-002",
            TestName = "Glucose",
            ResultValue = "95",
            Unit = "mg/dL",
            ObservedDate = new DateTime(2026, 11, 5)
        });

        var results = service.GetByPatientId("PAT-001");

        Assert.Single(results);
        Assert.All(results, result => Assert.Equal("PAT-001", result.PatientId));
    }
    [Fact]
    public void Update_WhenResultDoesNotExist_ReturnsFalse()
    {
        var repository = new InMemoryLabResultRepository();
        var service = new LabResultService(repository);

        var result = new LabResult
        {
            PatientId = "PAT-001",
            TestName = "Hemoglobin",
            ResultValue = "13.5",
            Unit = "g/dL",
            ObservedDate = new DateTime(2026, 11, 5)
        };

        var updated = service.Update(999, result);

        Assert.False(updated);
    }

    [Fact]
    public void Delete_WhenResultDoesNotExist_ReturnsFalse()
    {
        var repository = new InMemoryLabResultRepository();
        var service = new LabResultService(repository);

        var deleted = service.Delete(999);

        Assert.False(deleted);
    }
}