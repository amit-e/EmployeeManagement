CREATE PROCEDURE [dbo].[spTask_Insert]
	@EmployeeId int,
	@TaskText nvarchar(MAX),
	@AssignDate datetime,
	@DueDate datetime
AS

BEGIN
	INSERT INTO [dbo].[Task] (EmployeeId, TaskText, AssignDate, DueDate)
	OUTPUT inserted.Id
	VALUES (@EmployeeId, @TaskText, @AssignDate, @DueDate)

END