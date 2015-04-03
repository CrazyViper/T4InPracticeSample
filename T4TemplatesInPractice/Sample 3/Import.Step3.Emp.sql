
    
 -- создаем процедуру Source.ImportEmployee
IF OBJECT_ID ('Source.ImportEmployee', 'P') IS NOT NULL
    DROP PROCEDURE Source.ImportEmployeee
GO

CREATE PROCEDURE Source.ImportEmployee
AS
BEGIN

    INSERT INTO Staff.Employee
    (
         SourceId, LastName, FirstName, Birthday, DepartmentId
    )
    SELECT
         employee.Id, employee.LastName, employee.FirstName, employee.Birthday, department.Id
    FROM 
        Source.Employee AS employee
        INNER JOIN Staff.Department AS department
            ON employee.DepartmentId = department.SourceId
    ;

END
GO
