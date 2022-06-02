CREATE PROCEDURE [dbo].[spReport_Get]
	@Id int
AS

BEGIN
	SELECT	Id,
			ReportText,
			ReportDate,
			EmployeeId,
			ManagerId
	FROM	[dbo].[Report]
	WHERE	Id = @Id
END