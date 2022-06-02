CREATE PROCEDURE [dbo].[spEmployee_GetAll]
AS

BEGIN
	SELECT	[dbo].[Employee].Id,
			FirstName,
			LastName,
			TypeId,
			PositionId,
			[dbo].[Position].[Description] AS Position,
			ManagerId
	FROM	[dbo].[Employee]
			LEFT JOIN [dbo].[Position] ON [dbo].[Employee].PositionId = [dbo].[Position].Id
END