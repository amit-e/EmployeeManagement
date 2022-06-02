CREATE PROCEDURE [dbo].[spReport_Insert]
	@ReportText nvarchar(MAX),
	@ReportDate datetime,
	@EmployeeId int,
	@ManagerId int
AS

BEGIN
	INSERT INTO [dbo].[Report] (ReportText, ReportDate, EmployeeId, ManagerId)
	OUTPUT inserted.Id
	VALUES (@ReportText, @ReportDate, @EmployeeId, @ManagerId)

END
