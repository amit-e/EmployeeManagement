CREATE PROCEDURE [dbo].[spEmployee_Update]
	@Id int,
	@FirstName nvarchar(20),
	@LastName nvarchar(20),
	@TypeId tinyint,
	@PositionId smallint,
	@ManagerId int
AS

BEGIN
	UPDATE	[dbo].[Employee]
	SET		FirstName =  @FirstName,
			LastName = @LastName,
			TypeId = @TypeId,
			PositionId = @PositionId,
			ManagerId = @ManagerId
	
	WHERE	Id = @Id

END