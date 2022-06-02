CREATE PROCEDURE [dbo].[spReport_Delete]
	@Id INT
AS

BEGIN
	DELETE FROM	[dbo].[Report]
	WHERE		Id = @Id

END

