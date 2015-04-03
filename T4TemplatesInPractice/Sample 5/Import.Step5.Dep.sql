
    
 -- создаем процедуру Source.ImportDepartments
IF OBJECT_ID ('Source.ImportDepartments', 'P') IS NOT NULL
    DROP PROCEDURE Source.ImportDepartmentse
GO

CREATE PROCEDURE Source.ImportDepartments
AS
BEGIN
    
    IF (OBJECT_ID ( 'tempdb..#Staff_Department' ) IS NOT NULL)
        DROP TABLE #Staff_Department;
    CREATE TABLE #Staff_Department ([Id] bigint NOT NULL, [FullName] nvarchar(1000) NOT NULL, [ShortName] nvarchar(100) NOT NULL, [SourceId] bigint NOT NULL, [HasErrors] bit NOT NULL);

    INSERT INTO #Staff_Department
    (
         SourceId, FullName, ShortName
    )
    SELECT
         Id, FullName, ShortName
    FROM Source.Department
    ;

    UPDATE #Staff_Department
    SET HasErrors = 1
    WHERE FullName IS NULL
    ;

    INSERT INTO Staff.Department
    (
         FullName, ShortName, SourceId, Timestamp
    )
    SELECT
         FullName, ShortName, SourceId, SYSDATETIME()
    FROM #Staff_Department
    WHERE
        HasErrors = 0
    ;
END
GO
