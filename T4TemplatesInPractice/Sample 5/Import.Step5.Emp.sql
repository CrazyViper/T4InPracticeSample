
    
 -- создаем процедуру Source.ImportEmployee
IF OBJECT_ID ('Source.ImportEmployee', 'P') IS NOT NULL
    DROP PROCEDURE Source.ImportEmployeee
GO

CREATE PROCEDURE Source.ImportEmployee
AS
BEGIN
    
    IF (OBJECT_ID ( 'tempdb..#Staff_Employee' ) IS NOT NULL)
        DROP TABLE #Staff_Employee;
    CREATE TABLE #Staff_Employee ([Id] bigint NOT NULL, [FirstName] nvarchar(100) NOT NULL, [LastName] nvarchar(100) NOT NULL, [Birthday] date NOT NULL, [SourceId] bigint NOT NULL, [DepartmentId] bigint NOT NULL, [HasErrors] bit NOT NULL);

    INSERT INTO #Staff_Employee
    (
         SourceId, LastName, FirstName, Birthday, DepartmentId
    )
    SELECT
         employee.Id, employee.LastName, employee.FirstName, employee.Birthday, department.Id
    FROM 
        Source.Employee AS employee
        LEFT JOIN Staff.Department AS department
            ON employee.DepartmentId = department.SourceId
    ;

    UPDATE #Staff_Employee
    SET HasErrors = 1
    WHERE 
        DepartmentId IS NULL
        OR LastName IS NULL
        OR FirstName IS NULL
    ;

    INSERT INTO Staff.Employee
    (
         FirstName, LastName, Birthday, SourceId, DepartmentId, Timestamp
    )
    SELECT
         FirstName, LastName, Birthday, SourceId, DepartmentId, SYSDATETIME()
    FROM #Staff_Employee
    WHERE
        HasErrors = 0
    ;
END
GO
