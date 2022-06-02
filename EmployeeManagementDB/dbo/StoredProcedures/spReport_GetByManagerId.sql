CREATE PROCEDURE [dbo].[spReport_GetByManagerId]
	@ManagerId int
AS

BEGIN
	SELECT	Id,
			ReportText,
			ReportDate,
			EmployeeId,
			ManagerId
	FROM	[dbo].[Report]
	WHERE	ManagerId = @ManagerId
END
