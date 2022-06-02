/*
	Populate Tables
	---------------
*/

IF NOT EXISTS (SELECT 1 FROM [dbo].[EmployeeType])
BEGIN
	INSERT INTO [dbo].[EmployeeType] (Id, [Description])
	VALUES	(1, 'Employee'),
			(2, 'Manager')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Position])
BEGIN
	INSERT INTO [dbo].[Position] (Id, [Description])
	VALUES	(10, 'Software Developer'),
			(20, 'Development Team Leader'),
			(30, 'Product Manager'),
			(40, 'Accountant'),
			(50, 'CFO'),
			(60, 'CTO'),
			(100, 'CEO')
END


IF NOT EXISTS (SELECT 1 FROM [dbo].[Employee])
BEGIN
	INSERT INTO [dbo].[Employee] (FirstName, LastName, TypeId, PositionId, ManagerId)
	VALUES	('David',		'Moore',	2,	100,	1),
			('Jennifer',	'Cardinal', 2,	60,		1),
			('Anthony',		'Owens',	2,	50,		1),
			('Billy',		'Perkins',	1,	40,		3),
			('Janice',		'Jordan',	2,	30,		1),
			('Audrey',		'Jones',	1,	40,		3),
			('Robert',		'McDowell',	2,	20,		2),
			('Nancy',		'Borton',	1,	10,		7),
			('Wayne',		'White',	1,	10,		7),
			('Susan',		'Melton',	1,	10,		7)
END