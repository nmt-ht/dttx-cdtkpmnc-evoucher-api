ALTER TABLE [Partner]
DROP COLUMN [Image];

ALTER TABLE [Partner]
ADD [Image] VARBINARY(MAX);