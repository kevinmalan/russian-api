CREATE TABLE [dbo].[Alphabet](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Russian] [nvarchar](5) NOT NULL,
	[English] [nvarchar](5) NULL,
	[Examples] [nvarchar](255) NULL
)