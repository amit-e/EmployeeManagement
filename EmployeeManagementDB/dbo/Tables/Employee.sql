CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[FirstName] NVARCHAR(20) NOT NULL, 
	[LastName] NVARCHAR(20) NOT NULL, 
	[TypeId] TINYINT NOT NULL, 
	[PositionId] SMALLINT NULL, 
	[ManagerId] INT NULL, 
	CONSTRAINT [FK_Employee_EmployeeType] FOREIGN KEY ([TypeId]) REFERENCES [EmployeeType]([Id]), 
	CONSTRAINT [FK_Employee_Position] FOREIGN KEY ([PositionId]) REFERENCES [Position]([Id]), 
	CONSTRAINT [FK_Employee_Employee_Manager] FOREIGN KEY ([ManagerId]) REFERENCES [Employee]([Id]) 
)
