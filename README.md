# LabResults API

A .NET 9 Web API for creating, retrieving, updating, and deleting patient lab results.

## Run the API

Open `LabResults.sln` in Visual Studio and run the `LabResults` project using the HTTPS profile. Swagger opens at `/swagger`.

## Run the tests

In Visual Studio, open **Test → Test Explorer** and select **Run All**.

## Endpoints

- `POST /labresults` — create a lab result
- `GET /labresults/{id}` — get a result by ID
- `GET /labresults?patientId={patientId}` — list results for a patient
- `PUT /labresults/{id}` — update a result
- `DELETE /labresults/{id}` — delete a result

## Storage

The API uses an in-memory repository. Data is cleared when the application stops.

## SQL

The table definition, patient/date filtering query, and per-patient test count query are in `LabResults/sql/LabResults.sql`.