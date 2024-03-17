CREATE TABLE [dbo].[Phrases](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Russian] [nvarchar](1000) NULL,
	[English] [nvarchar](1000) NULL,
	[Category] [nvarchar](50) NULL
)