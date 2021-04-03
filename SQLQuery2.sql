﻿/*
Deployment script for BTMS1

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "BTMS1"
:setvar DefaultFilePrefix "BTMS1"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO

IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION
GO
PRINT N'Rename [dbo].[Bus DetailsTB].[Id] to Bus No';


GO
EXECUTE sp_rename @objname = N'[dbo].[Bus DetailsTB].[Id]', @newname = N'Bus No', @objtype = N'COLUMN';


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Bus Route Creator].[Id] (SqlSimpleColumn) will not be renamed to Route ID';


GO
PRINT N'Dropping [dbo].[DF__EmployeeT__Emplo__47DBAE45]...';


GO
ALTER TABLE [dbo].[EmployeeTB] DROP CONSTRAINT [DF__EmployeeT__Emplo__47DBAE45];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Starting rebuilding table [dbo].[Bus DetailsTB]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Bus DetailsTB] (
    [Bus No]       VARCHAR (20) NOT NULL,
    [Bus Name ]    VARCHAR (50) NULL,
    [Choose Route] VARCHAR (50) NULL,
    [Bus Type]     VARCHAR (50) NULL,
    [No of Seats]  INT          NULL,
    [Model]        VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Bus No] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Bus DetailsTB])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Bus DetailsTB] ([Bus No])
        SELECT   [Bus No]
        FROM     [dbo].[Bus DetailsTB]
        ORDER BY [Bus No] ASC;
    END

DROP TABLE [dbo].[Bus DetailsTB];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Bus DetailsTB]', N'Bus DetailsTB';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Starting rebuilding table [dbo].[EmployeeTB]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_EmployeeTB] (
    [EmployeeID]       INT           CONSTRAINT [DF__EmployeeT__Emplo__47DBAE45] DEFAULT ((1)) IDENTITY (1, 1) NOT NULL,
    [Employee Name]    VARCHAR (50)  NOT NULL,
    [Employee Address] VARCHAR (200) NOT NULL,
    [Employee PhoneNo] VARCHAR (15)  NOT NULL,
    [Father's Name]    VARCHAR (50)  NOT NULL,
    [Mother's Name]    VARCHAR (50)  NOT NULL,
    [Role/Designation] CHAR (10)     NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_EmployeeTB1] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[EmployeeTB])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_EmployeeTB] ON;
        INSERT INTO [dbo].[tmp_ms_xx_EmployeeTB] ([EmployeeID], [Employee Name], [Employee Address], [Employee PhoneNo], [Father's Name], [Mother's Name], [Role/Designation])
        SELECT   [EmployeeID],
                 [Employee Name],
                 [Employee Address],
                 [Employee PhoneNo],
                 [Father's Name],
                 [Mother's Name],
                 [Role/Designation]
        FROM     [dbo].[EmployeeTB]
        ORDER BY [EmployeeID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_EmployeeTB] OFF;
    END

DROP TABLE [dbo].[EmployeeTB];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_EmployeeTB]', N'EmployeeTB';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_EmployeeTB1]', N'PK_EmployeeTB', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[Bus Route Creator]...';


GO
CREATE TABLE [dbo].[Bus Route Creator] (
    [Route ID]             VARCHAR (50) NOT NULL,
    [Station Name]         VARCHAR (50) NULL,
    [Distance Form Source] INT          NULL,
    [Arrival Time]         TIME (7)     NULL,
    [Departure Time]       TIME (7)     NULL,
    PRIMARY KEY CLUSTERED ([Route ID] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'The transacted portion of the database update succeeded.'
COMMIT TRANSACTION
END
ELSE PRINT N'The transacted portion of the database update failed.'
GO
IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
GO
PRINT N'Update complete.';


GO
