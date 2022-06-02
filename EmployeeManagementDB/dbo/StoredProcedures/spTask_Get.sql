CREATE PROCEDURE [dbo].[spTask_Get]
	@Id int
AS

BEGIN
	SELECT	Id,
			EmployeeId,
			TaskText,
			AssignDate,
			DueDate
	FROM	[dbo].[Task]

	WHERE	Id = @Id
END
