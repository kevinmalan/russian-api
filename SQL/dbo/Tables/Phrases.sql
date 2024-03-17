CREATE TABLE [dbo].[Phrases](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] [uniqueidentifier] NOT NULL,
	[Russian] [nvarchar](1000) NULL,
	[English] [nvarchar](1000) NULL,
	[Category] [nvarchar](50) NULL
);
GO
CREATE INDEX IX_UniqueId
ON [dbo].[Phrases]([UniqueId])
GO