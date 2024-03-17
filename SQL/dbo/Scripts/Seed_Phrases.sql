INSERT INTO [dbo].[Phrases]
           ([UniqueId], [Russian], [English], [Category])
VALUES
           (NEWID(), N'Здравствуйте', 'Hello', 'Common'),
		   (NEWID(), N'Привет', 'Hello', 'Common'),
		   (NEWID(), N'Спасибо', 'Thank you', 'Common')