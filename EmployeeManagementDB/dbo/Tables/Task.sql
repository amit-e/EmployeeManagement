CREATE TABLE [dbo].[Task]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[EmployeeId] INT NOT NULL, 
	[TaskText] NVARCHAR(MAX) NOT NULL, 
	[AssignDate] DATETIME NOT NULL, 
	[DueDate] DATETIME NULL, 
	CONSTRAINT [FK_Task_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([Id])
)