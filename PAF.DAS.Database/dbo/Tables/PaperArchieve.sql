/*
The database must have a MEMORY_OPTIMIZED_DATA filegroup
before the memory optimized object can be created.

The bucket count should be set to about two times the 
maximum expected number of distinct values in the 
index key, rounded up to the nearest power of two.
*/

CREATE TABLE [dbo].[PaperArchieve]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY NONCLUSTERED DEFAULT newid(), 
    [PaperId] UNIQUEIDENTIFIER NULL, 
    [FileName] NVARCHAR(50) NULL, 
    [Location] NVARCHAR(200) NULL
)