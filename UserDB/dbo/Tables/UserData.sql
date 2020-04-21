CREATE TABLE [dbo].[UserData]
(
	[UserId] INT NOT NULL PRIMARY KEY,
	[UserFirstName] [NVARCHAR](50) NOT NULL,
	[UserLastName] [NVARCHAR](50) NOT NULL,
	[UserMail] [NVARCHAR](50) NOT NULL,
	[UserPassword] [NVARCHAR](MAX) NOT NULL,
	[UserRole] [NVARCHAR](10)
)
