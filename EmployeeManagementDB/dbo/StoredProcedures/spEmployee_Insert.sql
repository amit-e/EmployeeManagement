CREATE PROCEDURE [dbo].[spEmployee_Insert]
	@FirstName nvarchar(20),
	@LastName nvarchar(20),
	@TypeId tinyint,
	@PositionId smallint,
	@ManagerId int
AS

BEGIN
	INSERT INTO [dbo].[Employee] (FirstName, LastName, TypeId, PositionId, ManagerId)
	OUTPUT inserted.Id
	VALUES (@FirstName, @LastName, @TypeId, @PositionId, @ManagerId)

END