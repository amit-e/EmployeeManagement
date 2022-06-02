CREATE TABLE [dbo].[Report]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[ReportText] NVARCHAR(MAX) NULL, 
	[ReportDate] DATETIME NULL, 
	[EmployeeId] INT NULL, 
	[ManagerId] INT NULL, 
	CONSTRAINT [FK_Report_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([Id]), 
	CONSTRAINT [FK_Report_Employee_Manager] FOREIGN KEY ([ManagerId]) REFERENCES [Employee]([Id])

)
