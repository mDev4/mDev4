-- Sets the default schema for user # on [LVS]. Note: If schema does not exists, defaults to [dbo].
ALTER USER [InWMdBnVtHLogin_backendLVSUser] WITH DEFAULT_SCHEMA = [LVS];

-- If schema [LVS] does not exist, create it.
IF (SCHEMA_ID('LVS') IS NULL)
	BEGIN
		EXEC ('CREATE SCHEMA [LVS] AUTHORIZATION [dbo]')
	END

-- Drop any existing [LVS] tables and contents.
DROP TABLE IF EXISTS [LVS].[Student_Test];
DROP TABLE IF EXISTS [LVS].[Test];
DROP TABLE IF EXISTS [LVS].[Student_Group];
DROP TABLE IF EXISTS [LVS].[Announcement];
DROP TABLE IF EXISTS [LVS].[Group];
DROP TABLE IF EXISTS [LVS].[Student];
DROP TABLE IF EXISTS [LVS].[UserSettings];
DROP TABLE IF EXISTS [LVS].[User];

-- Create [LVS]. tables.

CREATE TABLE [LVS].[User]
(
	id         SMALLINT PRIMARY KEY             NOT NULL IDENTITY,
	username   VARCHAR(20)                      NOT NULL,
	password   VARCHAR(100)                     NOT NULL,
	clearance  TINYINT DEFAULT 3                NOT NULL,
	email      VARCHAR(50)                      NOT NULL,
	phone      VARCHAR(20)                      NOT NULL,
	first_name VARCHAR(20)                      NOT NULL,
	last_name  VARCHAR(30)                      NOT NULL,
	sex        VARCHAR(6)                       NOT NULL,
	CONSTRAINT UQ_User__username UNIQUE (username)
);
CREATE TABLE [LVS].[UserSettings]
(
	id             SMALLINT PRIMARY KEY                    NOT NULL IDENTITY,
	username       VARCHAR(20)                             NOT NULL,
	refresh_rate   SMALLINT DEFAULT 60                     NOT NULL,
	home_url       VARCHAR(20) DEFAULT 'announcements'     NOT NULL,
	selected_theme VARCHAR(20) DEFAULT 'default'           NOT NULL,
	CONSTRAINT UQI_UserSettings__ UNIQUE (id),
	CONSTRAINT UQ_UserSettings__username UNIQUE (username)
);
CREATE TABLE [LVS].[Announcement]
(
	id      SMALLINT PRIMARY KEY                                           NOT NULL IDENTITY,
	message TEXT                                                           NOT NULL,
	author  SMALLINT                                                       NOT NULL,
	title   VARCHAR(50)                                                    NOT NULL,
	type    VARCHAR(20)                                                    NOT NULL,
	date    smalldatetime DEFAULT (CONVERT([smalldatetime], getutcdate())) NOT NULL,
	CONSTRAINT UQ_Announcement__message_author_title UNIQUE (author, title, date)
);
CREATE TABLE [LVS].[Group]
(
	id                    SMALLINT PRIMARY KEY                          NOT NULL IDENTITY,
	name                  VARCHAR(20)                                   NOT NULL,
	current_academic_year SMALLINT                                      NOT NULL,
	current_year_of_study SMALLINT                                      NOT NULL,
	start_year            SMALLINT DEFAULT datepart(YEAR, GETUTCDATE()) NOT NULL
);
CREATE TABLE [LVS].[Student]
(
	id           INT PRIMARY KEY                               NOT NULL IDENTITY,
	student_code VARCHAR(20)                                   NOT NULL,
	particulars  TEXT,
	birth_date   DATE                                          NOT NULL,
	first_name   VARCHAR(20)                                   NOT NULL,
	middle_name  VARCHAR(20),
	last_name    VARCHAR(20)                                   NOT NULL,
	start_year   SMALLINT DEFAULT datepart(YEAR, GETUTCDATE()) NOT NULL,
	sex          VARCHAR(6)                                    NOT NULL,
	alumni       BOOLEAN DEFAULT '0'                           NOT NULL,
	CONSTRAINT UQ_Student__student_code UNIQUE (student_code)
);
CREATE TABLE [LVS].[Student_Group]
(
	group_id   SMALLINT NOT NULL,
	student_id INT      NOT NULL,
	CONSTRAINT PK__Student_Group_group_id_student_id PRIMARY KEY (group_id, student_id)
);
CREATE TABLE [LVS].[Test]
(
	[id]          SMALLINT PRIMARY KEY                     NOT NULL IDENTITY,
	[date]        DATE                                     NOT NULL,
	[title]       VARCHAR(50)                              NOT NULL,
	[description] VARCHAR(100)
);
CREATE TABLE [LVS].[Student_Test]
(
	[test_id]    SMALLINT    NOT NULL,
	[student_id] INT         NOT NULL,
	[grade]      VARCHAR(20),
	CONSTRAINT [PK__Student_Test_test_id_student_id] PRIMARY KEY ([test_id] ASC, [student_id] ASC),
	CONSTRAINT [FK__Student_Test_test_id] FOREIGN KEY (test_id) REFERENCES [LVS].[Test] (id),
	CONSTRAINT [FK__Student_Test_student_id] FOREIGN KEY (student_id) REFERENCES [LVS].[Student] (id)
);
-- Add constraints to created tables.
ALTER TABLE [LVS].[Announcement]
	ADD CONSTRAINT FK__Announcement_author FOREIGN KEY (author) REFERENCES [LVS].[User] (id);
CREATE UNIQUE INDEX PK__Announcement ON [LVS].[Announcement] (id);

CREATE UNIQUE INDEX UQ_Index__Group_id ON [LVS].[Group] (id);
CREATE UNIQUE INDEX PK__Group_id ON [LVS].[Group] (id);
ALTER TABLE [LVS].[Student_Group]
	ADD CONSTRAINT FK__Student_Group_group_id FOREIGN KEY (group_id) REFERENCES [LVS].[Group] (id);
ALTER TABLE [LVS].[Student_Group]
	ADD CONSTRAINT FK__Student_Group_student_id FOREIGN KEY (student_id) REFERENCES [LVS].[Student] (id);

CREATE UNIQUE INDEX UQ_Index__Student_first_name_last_name_birth_date_student_code ON [LVS].[Student] (first_name, last_name, birth_date, student_code);

CREATE UNIQUE INDEX UQ_Index__Student_Group_group_id_student_id ON [LVS].[Student_Group] (group_id, student_id);

ALTER TABLE [LVS].[UserSettings]
	ADD CONSTRAINT FK__UserSettings_username FOREIGN KEY (username) REFERENCES [LVS].[User] (username);
