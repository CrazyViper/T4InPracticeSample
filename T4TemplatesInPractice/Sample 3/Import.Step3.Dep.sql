
    
 -- создаем процедуру Source.ImportDepartments
IF OBJECT_ID ('Source.ImportDepartments', 'P') IS NOT NULL
    DROP PROCEDURE Source.ImportDepartmentse
GO

CREATE PROCEDURE Source.ImportDepartments
AS
BEGIN

    INSERT INTO Staff.Department
    (
         SourceId, FullName, ShortName
    )
    SELECT
         Id, FullName, ShortName
    FROM Source.Department
    ;

END
GO
