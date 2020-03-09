CREATE TABLE [Images](
	[id] int IDENTITY(1,1) PRIMARY KEY,
	[path] nvarchar(200)
); 

CREATE TABLE [Users](
	[id] int  IDENTITY(1,1) PRIMARY KEY,
	[userName] nvarchar(100),
	[birthday] dateTime,
	[imgId] int FOREIGN KEY REFERENCES [Images](id)
);

CREATE TABLE [Awards](
	[id] int IDENTITY(1,1) PRIMARY KEY,
	[title] nvarchar(100)
);

CREATE TABLE [UserAward](
	[userId] int NOT NULL FOREIGN KEY REFERENCES [Users](id),
	[awardId] int NOT NULL FOREIGN KEY REFERENCES [Awards](id),
	CONSTRAINT PK_UserAward PRIMARY KEY (userId, awardId),
);

CREATE TABLE [Roles](
	[id] int PRIMARY KEY,
	[role] nvarchar(100)
);

INSERT INTO [Roles]([id], [role]) 
VALUES
	(1,N'Admin'), 
	(2,N'User'), 
	(3,N'Guest');

CREATE TABLE [Account](
	[id] int IDENTITY(1,1) PRIMARY KEY,
	[login] nvarchar(100),
	[hashKey] varbinary(MAX),
	[roleId] int NOT NULL FOREIGN KEY REFERENCES [Roles](id)
);