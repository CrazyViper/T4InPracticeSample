---------------------------------------------------------------------------------
IF  NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Staff')
    EXEC('CREATE SCHEMA Staff AUTHORIZATION T4User')
GO
---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
IF  NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Source')
    EXEC('CREATE SCHEMA Source AUTHORIZATION T4User')
GO
---------------------------------------------------------------------------------

