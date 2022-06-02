CREATE PROCEDURE [dbo].[spTask_GetByEmployeeId]
	@EmployeeId int
AS

BEGIN
	SELECT	Id,
			EmployeeId,
			TaskText,
			AssignDate,
			DueDate
	FROM	[dbo].[Task]

	WHERE	EmployeeId = @EmployeeId
END