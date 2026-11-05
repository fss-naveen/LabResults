using LabResults.Contracts;
using LabResults.Models;
using LabResults.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabResults.Controllers;

[ApiController]
[Route("labresults")]
public class LabResultsController : ControllerBase
{
    private readonly ILabResultService _service;

    public LabResultsController(ILabResultService service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult<LabResult> Create(LabResultRequest request)
    {
        var result = new LabResult
        {
            PatientId = request.PatientId,
            TestName = request.TestName,
            ResultValue = request.ResultValue,
            Unit = request.Unit,
            ObservedDate = request.ObservedDate!.Value
        };

        var created = _service.Create(result);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet("{id:int}")]
    public ActionResult<LabResult> GetById(int id)
    {
        var result = _service.GetById(id);
        if (result is null)
        {
            return Problem(
                title: "Lab result not found",
                statusCode: StatusCodes.Status404NotFound);
        }

        return Ok(result);
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<LabResult>> GetByPatientId([FromQuery] string patientId)
    {
        if (string.IsNullOrWhiteSpace(patientId))
        {
            if (string.IsNullOrWhiteSpace(patientId))
            {
                return BadRequest("patientId is required.");
            } 
        } 

        return Ok(_service.GetByPatientId(patientId));
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, LabResultRequest request)
    {
        var result = new LabResult
        {
            Id = id,
            PatientId = request.PatientId,
            TestName = request.TestName,
            ResultValue = request.ResultValue,
            Unit = request.Unit,
            ObservedDate = request.ObservedDate!.Value
        };

        if (!_service.Update(id, result))
        {
            return Problem(
                title: "Lab result not found",
                statusCode: StatusCodes.Status404NotFound);
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (!_service.Delete(id))
        {
            return Problem(
                title: "Lab result not found",
                statusCode: StatusCodes.Status404NotFound);
        }

        return NoContent();
    }
}
