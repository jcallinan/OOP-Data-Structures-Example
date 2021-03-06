USE [master]
GO
/****** Object:  Database [ARGReports]    Script Date: 4/5/2020 8:59:09 PM ******/
CREATE DATABASE [ARGReports]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ARGReports', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ARGReports.mdf' , SIZE = 1996800KB , MAXSIZE = UNLIMITED, FILEGROWTH = 204800KB )
 LOG ON 
( NAME = N'ARGReports_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ARGReports_log.ldf' , SIZE = 2667072KB , MAXSIZE = 2048GB , FILEGROWTH = 204800KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ARGReports] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ARGReports].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ARGReports] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ARGReports] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ARGReports] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ARGReports] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ARGReports] SET ARITHABORT OFF 
GO
ALTER DATABASE [ARGReports] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ARGReports] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ARGReports] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ARGReports] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ARGReports] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ARGReports] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ARGReports] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ARGReports] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ARGReports] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ARGReports] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ARGReports] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ARGReports] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ARGReports] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ARGReports] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ARGReports] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ARGReports] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ARGReports] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ARGReports] SET RECOVERY FULL 
GO
ALTER DATABASE [ARGReports] SET  MULTI_USER 
GO
ALTER DATABASE [ARGReports] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ARGReports] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ARGReports] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ARGReports] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ARGReports] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ARGReports', N'ON'
GO
ALTER DATABASE [ARGReports] SET QUERY_STORE = OFF
GO
USE [ARGReports]
GO
/****** Object:  User [timeEntryUser]    Script Date: 4/5/2020 8:59:09 PM ******/
CREATE USER [timeEntryUser] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [tank]    Script Date: 4/5/2020 8:59:09 PM ******/
CREATE USER [tank] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [suiteCRMReadOnly]    Script Date: 4/5/2020 8:59:09 PM ******/
CREATE USER [suiteCRMReadOnly] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [suiteCRM]    Script Date: 4/5/2020 8:59:09 PM ******/
CREATE USER [suiteCRM] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [securityUser]    Script Date: 4/5/2020 8:59:09 PM ******/
CREATE USER [securityUser] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [bradSQL2User]    Script Date: 4/5/2020 8:59:09 PM ******/
CREATE USER [bradSQL2User] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [BoardReportUser]    Script Date: 4/5/2020 8:59:09 PM ******/
CREATE USER [BoardReportUser] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [bdsql1User]    Script Date: 4/5/2020 8:59:09 PM ******/
CREATE USER [bdsql1User] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ARGReportsUser]    Script Date: 4/5/2020 8:59:09 PM ******/
CREATE USER [ARGReportsUser] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ARGReportsReadOnly]    Script Date: 4/5/2020 8:59:09 PM ******/
CREATE USER [ARGReportsReadOnly] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [timeEntryUser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [timeEntryUser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [suiteCRMReadOnly]
GO
ALTER ROLE [db_datareader] ADD MEMBER [suiteCRM]
GO
ALTER ROLE [db_datareader] ADD MEMBER [securityUser]
GO
ALTER ROLE [db_owner] ADD MEMBER [bradSQL2User]
GO
ALTER ROLE [db_datareader] ADD MEMBER [BoardReportUser]
GO
ALTER ROLE [db_owner] ADD MEMBER [bdsql1User]
GO
ALTER ROLE [db_owner] ADD MEMBER [ARGReportsUser]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [ARGReportsUser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [ARGReportsReadOnly]
GO
/****** Object:  UserDefinedDataType [dbo].[ALARM_REFERENCE_ID]    Script Date: 4/5/2020 8:59:10 PM ******/
CREATE TYPE [dbo].[ALARM_REFERENCE_ID] FROM [varchar](128) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[SQL_DATE_TIME]    Script Date: 4/5/2020 8:59:10 PM ******/
CREATE TYPE [dbo].[SQL_DATE_TIME] FROM [datetime] NULL
GO
/****** Object:  UserDefinedDataType [dbo].[SQL_LONG]    Script Date: 4/5/2020 8:59:10 PM ******/
CREATE TYPE [dbo].[SQL_LONG] FROM [int] NOT NULL
GO
/****** Object:  UserDefinedFunction [dbo].[GetLastGaugeAmount]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetLastGaugeAmount]
(
	@tankNumber int,
	@dateTime datetime
)
RETURNS float
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Gallons float

	-- Add the T-SQL statements to compute the return value here
	SELECT @Gallons =  cast( gallons as float) from PackagingPlantTankGaugingData where tankNumber = @tankNumber 
	and datetimetaken < @datetime order by datetimetaken asc
	DECLARE @intGallons int
	SET @intGallons = round(@gallons,0)
	SET @gallons = @intgallons
	-- Return the result of the function
	RETURN @gallons

END
GO
/****** Object:  UserDefinedFunction [dbo].[GetRackLoadedFrom]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetRackLoadedFrom]
(
	@orderNumber varchar(50)
)
RETURNS varchar(10)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @PRESET varchar(10)

	-- Add the T-SQL statements to compute the return value here
	select @PRESET =         LOADING_PRESET_CODE  FROM [ORDER_LOADED] 
	where order_id = @orderNumber
	-- Return the result of the function
	set @PRESET=REPLACE(@PRESET,'ARM','Rack ')
	set @PRESET=REPLACE(@PRESET,'-',' ')
	RETURN @PRESET

END
GO
/****** Object:  UserDefinedFunction [dbo].[iSeriesDateToISO]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[iSeriesDateToISO](@Value VarChar(8))
Returns VarChar(10)
As 
Begin
  
  Return Left(@Value,4) + '-' + SUBSTRING(@Value,5,2) + '-' + Right(@Value,2)

End
GO
/****** Object:  UserDefinedFunction [dbo].[IsInteger]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[IsInteger](@Value VarChar(18))
Returns Bit
As 
Begin
  
  Return IsNull(
     (Select Case When CharIndex('.', @Value) > 0 
                  Then Case When Convert(int, ParseName(@Value, 1)) <> 0
                            Then 0
                            Else 1
                            End
                  Else 1
                  End
      Where IsNumeric(@Value + 'e0') = 1), 0)

End
GO
/****** Object:  UserDefinedFunction [dbo].[ISODateToiSeries]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[ISODateToiSeries](@Value VarChar(10))
Returns VarChar(8)
As 
Begin
  
  Return Replace(@Value,'-','')

End
GO
/****** Object:  Table [dbo].[localGGSPROD]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[localGGSPROD](
	[TPDEL] [char](1) NOT NULL,
	[TPFIL1] [char](6) NOT NULL,
	[TPCONO] [numeric](2, 0) NOT NULL,
	[TPPROD] [char](4) NOT NULL,
	[TPDESC] [char](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[localProductsAndDescriptions]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[localProductsAndDescriptions]
AS
SELECT     TPPROD, TPDESC
FROM         dbo.localGGSPROD
GO
/****** Object:  Table [dbo].[localGINTKHS]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[localGINTKHS](
	[THDEL] [char](1) NOT NULL,
	[THCO] [numeric](2, 0) NOT NULL,
	[THLOC] [char](3) NOT NULL,
	[THTANK] [char](4) NOT NULL,
	[THEFDT] [numeric](7, 0) NOT NULL,
	[THPRCD] [char](4) NOT NULL,
	[THEFD8] [numeric](8, 0) NOT NULL,
	[THF001] [char](3) NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_localGINTKHS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[localLatestTankChanges]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[localLatestTankChanges]
AS
SELECT     TOP (100) PERCENT dbo.iSeriesDateToISO(t.THEFD8) AS ISODate, t.THTANK, t.THPRCD
FROM         (SELECT     MAX(THEFD8) AS THEFD8, THTANK
                       FROM          dbo.localGINTKHS
                       GROUP BY THTANK) AS m INNER JOIN
                      dbo.localGINTKHS AS t ON t.THTANK = m.THTANK AND t.THEFD8 = m.THEFD8
GROUP BY t.THTANK, t.THEFD8, t.THPRCD
ORDER BY ISODate DESC
GO
/****** Object:  Table [dbo].[localGINCHRT]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[localGINCHRT](
	[TCDEL] [char](1) NOT NULL,
	[TCCO] [numeric](2, 0) NOT NULL,
	[TCLOC] [char](3) NOT NULL,
	[TCTANK] [char](4) NOT NULL,
	[TCHTFT] [numeric](3, 0) NOT NULL,
	[TCHTIN] [numeric](2, 0) NOT NULL,
	[TCDIFT] [numeric](3, 0) NOT NULL,
	[TCDIIN] [numeric](2, 0) NOT NULL,
	[TCSFFT] [numeric](3, 0) NOT NULL,
	[TCSFIN] [numeric](2, 0) NOT NULL,
	[TCMXQT] [numeric](9, 0) NOT NULL,
	[TCMXQF] [numeric](2, 2) NOT NULL,
	[TCSPFT] [numeric](2, 0) NOT NULL,
	[TCSPIN] [numeric](2, 0) NOT NULL,
	[TCSPQT] [numeric](9, 0) NOT NULL,
	[TCSPQF] [numeric](2, 2) NOT NULL,
	[TCBTTY] [char](1) NOT NULL,
	[TCBTFT] [numeric](1, 0) NOT NULL,
	[TCBTIN] [numeric](2, 0) NOT NULL,
	[TCUNIT] [char](6) NOT NULL,
	[TCIO] [char](1) NOT NULL,
	[TCCOUN] [char](6) NOT NULL,
	[TCENUN] [char](6) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[localTanksWithLatestProducts]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[localTanksWithLatestProducts]
AS
SELECT DISTINCT 
                         TOP (100) PERCENT dbo.localGINCHRT.TCTANK, dbo.localGINCHRT.TCUNIT, dbo.localLatestTankChanges.THPRCD, dbo.localProductsAndDescriptions.TPDESC, dbo.localGINCHRT.TCHTIN, dbo.localGINCHRT.TCLOC
FROM            dbo.localProductsAndDescriptions RIGHT OUTER JOIN
                         dbo.localLatestTankChanges ON LTRIM(dbo.localProductsAndDescriptions.TPPROD) = LTRIM(dbo.localLatestTankChanges.THPRCD) RIGHT OUTER JOIN
                         dbo.localGINCHRT ON LTRIM(dbo.localLatestTankChanges.THTANK) = LTRIM(dbo.localGINCHRT.TCTANK)
ORDER BY dbo.localGINCHRT.TCUNIT, dbo.localGINCHRT.TCTANK
GO
/****** Object:  Table [dbo].[ApplicationLog]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationLog](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[AppName] [varchar](50) NULL,
	[AppFunction] [varchar](50) NULL,
	[AppDetails] [text] NULL,
	[DateDone] [datetime] NULL,
 CONSTRAINT [PK_ApplicationLog] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Tank_Gauging_Temp_Errors]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Tank_Gauging_Temp_Errors]
AS
SELECT        LogID, AppName, AppFunction, AppDetails, DateDone
FROM            dbo.ApplicationLog
WHERE        (AppDetails LIKE '%high%') OR
                         (AppDetails LIKE '%low%') AND (AppFunction <> 'EmailTasks')
GO
/****** Object:  Table [dbo].[localGINTANK]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[localGINTANK](
	[INDEL] [varchar](50) NULL,
	[INCO] [varchar](50) NULL,
	[INLOC] [varchar](50) NULL,
	[INPRCD] [varchar](50) NULL,
	[INTNK] [varchar](50) NULL,
	[INXKEY] [varchar](50) NULL,
	[INTDES] [varchar](50) NULL,
	[INUNCD] [varchar](50) NULL,
	[INCOUN] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AutomatedTanks]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutomatedTanks](
	[TankNumber] [char](4) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TankRoute]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TankRoute](
	[TankNumber] [char](4) NOT NULL,
	[OrdinalNumber] [int] NULL,
	[Unit] [varchar](50) NULL,
	[TankNumberID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TankRoute] PRIMARY KEY CLUSTERED 
(
	[TankNumberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[localTanksWithLatestProducts_NoAutomatedTanks]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[localTanksWithLatestProducts_NoAutomatedTanks]
AS
SELECT DISTINCT 
                         TOP (100) PERCENT dbo.localGINCHRT.TCTANK, dbo.localGINCHRT.TCUNIT, dbo.localLatestTankChanges.THPRCD, dbo.localProductsAndDescriptions.TPDESC, dbo.localGINCHRT.TCHTIN, dbo.localGINCHRT.TCLOC, 
                         dbo.TankRoute.OrdinalNumber
FROM            dbo.TankRoute RIGHT OUTER JOIN
                         dbo.localGINCHRT ON LTRIM(dbo.TankRoute.TankNumber) = LTRIM(dbo.localGINCHRT.TCTANK) LEFT OUTER JOIN
                         dbo.localProductsAndDescriptions RIGHT OUTER JOIN
                         dbo.localLatestTankChanges ON LTRIM(dbo.localProductsAndDescriptions.TPPROD) = LTRIM(dbo.localLatestTankChanges.THPRCD) ON LTRIM(dbo.localGINCHRT.TCTANK) = LTRIM(dbo.localLatestTankChanges.THTANK) 
                         INNER JOIN
                         dbo.localGINTANK ON LTRIM(dbo.localGINCHRT.TCTANK) = dbo.localGINTANK.INTNK
WHERE        (dbo.localGINCHRT.TCTANK NOT IN
                             (SELECT        TankNumber
                               FROM            dbo.AutomatedTanks))
ORDER BY dbo.TankRoute.OrdinalNumber, dbo.localGINCHRT.TCUNIT, dbo.localGINCHRT.TCTANK
GO
/****** Object:  Table [dbo].[TankGaugingData]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TankGaugingData](
	[TankNumber] [varchar](50) NOT NULL,
	[DateTimeTaken] [datetime] NOT NULL,
	[Feet] [int] NULL,
	[Inches] [int] NULL,
	[InchesPart] [int] NULL,
	[Temperature] [int] NULL,
	[Inspection] [varchar](10) NULL,
	[ProdCode] [varchar](50) NULL,
	[ProdDescription] [varchar](100) NULL,
	[InOutage] [varchar](1) NULL,
	[TankStatus] [varchar](50) NULL,
	[HazardConditions] [bit] NULL,
	[WaterCheck] [bit] NULL,
	[EmergContainmentValve] [bit] NULL,
	[ActionRequired] [bit] NULL,
	[InspectionRecord] [bit] NULL,
 CONSTRAINT [PK_TankGaugingData] PRIMARY KEY CLUSTERED 
(
	[TankNumber] ASC,
	[DateTimeTaken] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[TankGaugingAllTank24hr]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TankGaugingAllTank24hr]
AS
SELECT        TOP (100) PERCENT dbo.TankGaugingData.TankNumber, dbo.TankGaugingData.DateTimeTaken, dbo.TankGaugingData.Feet, dbo.TankGaugingData.Inches, 
                         dbo.TankGaugingData.InchesPart, dbo.TankGaugingData.Temperature, dbo.TankGaugingData.Inspection, dbo.TankGaugingData.ProdCode, 
                         dbo.TankGaugingData.ProdDescription, dbo.TankGaugingData.InOutage, dbo.TankGaugingData.TankStatus, 
                         dbo.localTanksWithLatestProducts_NoAutomatedTanks.TCUNIT
FROM            dbo.TankGaugingData INNER JOIN
                         dbo.localTanksWithLatestProducts_NoAutomatedTanks ON 
                         dbo.TankGaugingData.TankNumber = dbo.localTanksWithLatestProducts_NoAutomatedTanks.TCTANK INNER JOIN
                         dbo.TankRoute ON dbo.TankGaugingData.TankNumber = dbo.TankRoute.TankNumber
WHERE        (dbo.TankGaugingData.TankStatus IS NOT NULL) AND (dbo.TankGaugingData.DateTimeTaken > GETDATE() - 1)
ORDER BY dbo.TankGaugingData.DateTimeTaken DESC
GO
/****** Object:  View [dbo].[TankGaugingData_2020]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TankGaugingData_2020]
AS
SELECT        dbo.TankGaugingData.TankNumber, dbo.TankGaugingData.DateTimeTaken, dbo.TankGaugingData.Feet, dbo.TankGaugingData.Inches, dbo.TankGaugingData.InchesPart, dbo.TankGaugingData.Temperature, 
                         dbo.TankGaugingData.Inspection, dbo.TankGaugingData.ProdCode, dbo.TankGaugingData.ProdDescription, dbo.TankGaugingData.TankStatus, dbo.TankGaugingData.HazardConditions, dbo.TankGaugingData.WaterCheck, 
                         dbo.TankGaugingData.EmergContainmentValve, dbo.TankGaugingData.ActionRequired, dbo.localGINCHRT.TCUNIT
FROM            dbo.TankGaugingData INNER JOIN
                         dbo.localGINCHRT ON dbo.TankGaugingData.TankNumber = dbo.localGINCHRT.TCTANK
WHERE        (dbo.TankGaugingData.DateTimeTaken > '12/31/2019')
GO
/****** Object:  View [dbo].[Temperature_Errors_In_Tank_Gauging]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Temperature_Errors_In_Tank_Gauging]
AS
SELECT        LogID, AppName, AppFunction, AppDetails, DateDone
FROM            dbo.ApplicationLog
WHERE        (AppFunction = 'TankGaugingImport_TemperatureCheck')
GO
/****** Object:  View [dbo].[Tank_Gauging_Live_Data]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Tank_Gauging_Live_Data]
AS
SELECT        dbo.localGINCHRT.TCUNIT, CAST(dbo.TankGaugingData.TankNumber AS int) AS TankNumber, dbo.TankGaugingData.DateTimeTaken, dbo.TankGaugingData.Feet, dbo.TankGaugingData.Inches, dbo.TankGaugingData.InchesPart, 
                         dbo.TankGaugingData.Temperature, dbo.TankGaugingData.Inspection, dbo.TankGaugingData.ProdCode, dbo.TankGaugingData.ProdDescription, dbo.TankGaugingData.InOutage, dbo.TankGaugingData.TankStatus, 
                         dbo.TankGaugingData.HazardConditions, dbo.TankGaugingData.WaterCheck, dbo.TankGaugingData.EmergContainmentValve, dbo.TankGaugingData.ActionRequired
FROM            dbo.localGINCHRT INNER JOIN
                         dbo.TankGaugingData ON CONVERT(int, dbo.localGINCHRT.TCTANK) = CONVERT(int, dbo.TankGaugingData.TankNumber)
GO
/****** Object:  View [dbo].[Todays_Tank_Gauges]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Todays_Tank_Gauges]
AS
SELECT DISTINCT TankNumber
FROM            dbo.TankGaugingData
WHERE        (ABS(DATEDIFF(day, GETDATE(), DateTimeTaken)) < 4)
GO
/****** Object:  View [dbo].[TankGaugingData_2019]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TankGaugingData_2019]
AS
SELECT        TankNumber, DateTimeTaken, Feet, Inches, InchesPart, Temperature, Inspection, ProdCode, ProdDescription, InOutage, TankStatus, HazardConditions, WaterCheck, EmergContainmentValve, ActionRequired
FROM            dbo.TankGaugingData
WHERE        (DateTimeTaken > '12/31/2018')
GO
/****** Object:  View [dbo].[Daily_Gauge_Sheet]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Daily_Gauge_Sheet]
AS
SELECT     TankNumber, DateTimeTaken, Feet, Inches, InchesPart, Temperature, ProdCode, ProdDescription
FROM         dbo.TankGaugingData
GO
/****** Object:  Table [dbo].[ProductTempRanges]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTempRanges](
	[ProdCode] [varchar](50) NOT NULL,
	[LowTemp] [int] NULL,
	[HighTemp] [int] NULL,
 CONSTRAINT [PK_ProductTempRanges] PRIMARY KEY CLUSTERED 
(
	[ProdCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[TanksOverTemp]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TanksOverTemp]
AS
SELECT        dbo.TankGaugingData.TankNumber, dbo.TankGaugingData.DateTimeTaken, dbo.TankGaugingData.Feet, dbo.TankGaugingData.Inches, dbo.TankGaugingData.InchesPart, dbo.TankGaugingData.ProdCode, 
                         dbo.TankGaugingData.Temperature, dbo.ProductTempRanges.LowTemp, dbo.ProductTempRanges.HighTemp
FROM            dbo.TankGaugingData INNER JOIN
                         dbo.ProductTempRanges ON dbo.TankGaugingData.ProdCode = dbo.ProductTempRanges.ProdCode AND dbo.TankGaugingData.Temperature > dbo.ProductTempRanges.HighTemp
WHERE        (dbo.TankGaugingData.DateTimeTaken > DATEADD(day, - 1, GETDATE()))
GO
/****** Object:  Table [dbo].[ProductCodesToTrack]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCodesToTrack](
	[ProductCode] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProductCodesToTrack] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TankInspectionList]    Script Date: 4/5/2020 8:59:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TankInspectionList](
	[TankID] [int] IDENTITY(1,1) NOT NULL,
	[TankNumber] [varchar](50) NULL,
	[Desctiption] [varchar](max) NULL,
	[TankUnit] [varchar](50) NULL,
	[TankOrder] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TankGaugingData"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 272
               Right = 370
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Daily_Gauge_Sheet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Daily_Gauge_Sheet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "m"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 84
               Right = 205
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "t"
            Begin Extent = 
               Top = 6
               Left = 243
               Bottom = 114
               Right = 410
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'localLatestTankChanges'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'localLatestTankChanges'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "localGGSPROD"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'localProductsAndDescriptions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'localProductsAndDescriptions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[44] 4[12] 2[25] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "localProductsAndDescriptions"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 84
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "localLatestTankChanges"
            Begin Extent = 
               Top = 82
               Left = 427
               Bottom = 280
               Right = 578
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "localGINCHRT"
            Begin Extent = 
               Top = 17
               Left = 572
               Bottom = 125
               Right = 723
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'localTanksWithLatestProducts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'localTanksWithLatestProducts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[34] 4[4] 2[43] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TankRoute"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 101
               Right = 210
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "localGINCHRT"
            Begin Extent = 
               Top = 0
               Left = 473
               Bottom = 270
               Right = 762
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "localProductsAndDescriptions"
            Begin Extent = 
               Top = 102
               Left = 38
               Bottom = 261
               Right = 195
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "localLatestTankChanges"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 272
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "localGINTANK"
            Begin Extent = 
               Top = 6
               Left = 248
               Bottom = 136
               Right = 418
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'localTanksWithLatestProducts_NoAutomatedTanks'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'localTanksWithLatestProducts_NoAutomatedTanks'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'localTanksWithLatestProducts_NoAutomatedTanks'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[52] 4[9] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "localGINCHRT"
            Begin Extent = 
               Top = 0
               Left = 386
               Bottom = 322
               Right = 537
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TankGaugingData"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 295
               Right = 193
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 28
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Tank_Gauging_Live_Data'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Tank_Gauging_Live_Data'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ApplicationLog"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Tank_Gauging_Temp_Errors'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Tank_Gauging_Temp_Errors'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TankGaugingData"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "localTanksWithLatestProducts_NoAutomatedTanks"
            Begin Extent = 
               Top = 6
               Left = 250
               Bottom = 135
               Right = 422
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TankRoute"
            Begin Extent = 
               Top = 6
               Left = 460
               Bottom = 101
               Right = 632
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TankGaugingAllTank24hr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TankGaugingAllTank24hr'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TankGaugingData"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 259
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TankGaugingData_2019'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TankGaugingData_2019'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TankGaugingData"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 259
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "localGINCHRT"
            Begin Extent = 
               Top = 6
               Left = 297
               Bottom = 336
               Right = 467
            End
            DisplayFlags = 280
            TopColumn = 50
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 17
         Width = 284
         Width = 1500
         Width = 4035
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TankGaugingData_2020'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TankGaugingData_2020'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TankGaugingData"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 259
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProductTempRanges"
            Begin Extent = 
               Top = 6
               Left = 297
               Bottom = 119
               Right = 467
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TanksOverTemp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TanksOverTemp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ApplicationLog"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 237
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 3420
         Width = 7110
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Temperature_Errors_In_Tank_Gauging'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Temperature_Errors_In_Tank_Gauging'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TankGaugingData"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 259
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 17
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Todays_Tank_Gauges'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Todays_Tank_Gauges'
GO
USE [master]
GO
ALTER DATABASE [ARGReports] SET  READ_WRITE 
GO
