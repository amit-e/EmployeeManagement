CREATE PROCEDURE [dbo].[spTask_Update]
	@Id int,
	@TaskText nvarchar(MAX),
	@DueDate datetime

AS

BEGIN
	UPDATE	[dbo].[Task]
	SET		TaskText = @TaskText,
			DueDate = @DueDate
	
	WHERE	Id = @Id

END
