CREATE TABLE [dbo].[Alphabet](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UniqueId] [uniqueidentifier] NOT NULL,
	[Russian] [nvarchar](5) NOT NULL,
	[English] [nvarchar](5) NOT NULL,
	[Examples] [nvarchar](255) NULL
);
GO
CREATE INDEX IX_UniqueId
ON [dbo].[Alphabet]([UniqueId])
GO