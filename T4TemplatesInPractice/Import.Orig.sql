-- создаем процедуру Source.ImportDepartments
IF OBJECT_ID ('Source.ImportDepartments', 'P') IS NOT NULL
    DROP PROCEDURE Source.ImportDepartments
GO

CREATE PROCEDURE Source.ImportDepartments
AS
BEGIN

    INSERT INTO Staff.Department
        (SourceId,FullName,ShortName)
    SELECT
        Id,FullName,ShortName
    FROM Source.Department
    ;

END
GO

 -- создаем процедуру Source.ImportEmployee
IF OBJECT_ID ('Source.ImportEmployee', 'P') IS NOT NULL
    DROP PROCEDURE Source.ImportEmployee
GO

CREATE PROCEDURE Source.ImportEmployee
AS
BEGIN

   INSERT INTO Staff.Employee
        (SourceId,LastName,FirstName,DepartmentId)
    SELECT
        Id,LastName,FirstName,DepartmentId
    FROM Source.Employee
    ;

END
GO
