CREATE TABLE dbo.LabResults
(
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    PatientId     NVARCHAR(100) NOT NULL,
    TestName      NVARCHAR(200) NOT NULL,
    ResultValue   NVARCHAR(100) NOT NULL,
    Unit          NVARCHAR(50) NOT NULL,
    ObservedDate  DATETIME2 NOT NULL
);

CREATE INDEX IX_LabResults_PatientId_ObservedDate
    ON dbo.LabResults (PatientId, ObservedDate DESC);

-- Filter: lab results for one patient in a date range
SELECT Id, PatientId, TestName, ResultValue, Unit, ObservedDate
FROM dbo.LabResults
WHERE PatientId = @PatientId
  AND ObservedDate >= @StartDate
  AND ObservedDate < @EndDate
ORDER BY ObservedDate DESC;

-- Aggregate: number of tests recorded per patient
SELECT PatientId, COUNT(*) AS TestCount
FROM dbo.LabResults
GROUP BY PatientId
ORDER BY PatientId;