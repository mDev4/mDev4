-- Sets the default schema for user # on [LVS]. Note: If schema does not exists, defaults to [dbo].
ALTER USER [InWMdBnVtHLogin_backendLVSUser] WITH DEFAULT_SCHEMA = [LVS];

SET IDENTITY_INSERT [LVS].[Group] ON
INSERT INTO [LVS].[Group] ([id], [name], [current_academic_year], [current_year_of_study], [start_year])
VALUES (1, N'Group 1', 2004, 1, 2004), (2, N'Group 2', 2004, 2, 2003), (3, N'Group 3', 2004, 3, 2002),
	(4, N'Group 4', 2004, 4, 2001), (5, N'Group 5', 2004, 5, 2000), (6, N'Group 6', 2004, 6, 1999),
	(7, N'Group 7', 2004, 7, 1998), (8, N'Group 8', 2004, 8, 1997), (9, N'Group 1', 2005, 1, 2005),
	(10, N'Group 2', 2005, 2, 2004), (11, N'Group 3', 2005, 3, 2003), (12, N'Group 4', 2005, 4, 2002),
	(13, N'Group 5', 2005, 5, 2001), (14, N'Group 6', 2005, 6, 2000), (15, N'Group 7', 2005, 7, 1999),
	(16, N'Group 8', 2005, 8, 1998);
SET IDENTITY_INSERT [LVS].[Group] OFF

INSERT INTO [LVS].[Student_Group] ([group_id], [student_id])
VALUES (1, 1), (1, 2), (1, 3), (1, 4), (2, 1), (2, 2), (2, 3), (2, 4), (3, 1), (3, 2), (3, 3), (3, 4), (4, 1), (4, 2),
	(4, 3), (4, 4), (5, 1), (5, 2), (5, 3), (5, 4), (6, 1), (6, 2), (6, 3), (6, 4), (7, 1), (7, 2), (7, 3), (7, 4),
	(8, 1), (8, 2), (8, 3), (8, 4), (9, 1), (9, 2), (9, 3), (9, 4), (10, 1), (10, 2), (10, 3), (10, 4), (11, 1), (11, 2),
	(11, 3), (11, 4), (12, 1), (12, 2), (12, 3), (12, 4), (13, 1), (13, 2), (13, 3), (13, 4), (14, 1), (14, 2)
	, (14, 3), (14, 4), (15, 1), (15, 2), (15, 3), (15, 4), (16, 1), (16, 2), (16, 3), (16, 4);

SET IDENTITY_INSERT [LVS].[Student] ON
INSERT INTO [LVS].[Student] ([id], [student_code], [particulars], [birth_date], [first_name], [middle_name], [last_name], [start_year])
VALUES (1, N'Kuijlel001', N'Cat allergy', N'1997-08-23', N'Lars', N'Christiaan', N'Kuijlenburg', 2005), (2, N'Shayan001', N'Midget', N'1992-09-22', N'Nick', N'The bomb', N'Shayan', 2004), (3, N'Zammir001', N'From Malta', N'1998-09-22', N'Ryan', N'The Weirdo', N'Zammit', 1995), (4, N'Tester1', N'none', N'2222-09-22', N'test1', N'test1', N'test1', 1998);
SET IDENTITY_INSERT [LVS].[Student] OFF

SET IDENTITY_INSERT [LVS].[Student] ON
INSERT INTO [LVS].[User] ([id], [username], [password], [email], [phone], [first_name], [last_name])
VALUES (1, N'test', N'test', [nickmails@me.com], [0123456789], [Nick], [Shayan]);
SET IDENTITY_INSERT [LVS].[Student] OFF
