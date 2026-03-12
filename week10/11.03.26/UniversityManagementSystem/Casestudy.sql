SELECT TOP (1000) [BookModelId]
      ,[BookName]
      ,[Description]
      ,[Price]
  FROM [BookDataBase].[dbo].[tblBook]

ALTER TABLE tblBook
ADD Author NVARCHAR(100);

UPDATE tblBook
SET Author = 'Unknown'
WHERE Author IS NULL;
