/*
The database must have a MEMORY_OPTIMIZED_DATA filegroup
before the memory optimized object can be created.

The bucket count should be set to about two times the 
maximum expected number of distinct values in the 
index key, rounded up to the nearest power of two.
*/

CREATE TABLE [dbo].[Paper]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY NONCLUSTERED DEFAULT newid(), 
    [Title] NVARCHAR(100) NULL, 
    [Author] NVARCHAR(100) NULL, 
    [DocumentType] INT NULL, 
    [YearSubmitted] NCHAR(4) NULL, 
    [Remarks] NVARCHAR(300) NULL
)