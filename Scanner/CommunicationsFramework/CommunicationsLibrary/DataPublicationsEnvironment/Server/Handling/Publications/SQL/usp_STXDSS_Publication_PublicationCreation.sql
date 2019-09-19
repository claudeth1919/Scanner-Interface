-- creating the store procedure
IF EXISTS 
(
	SELECT 	name 
	FROM   	sysobjects 
	WHERE  	name = N'usp_STXDSS_Publication_PublicationCreation' 
	   	AND 	  type = 'P'
)
	DROP PROCEDURE usp_STXDSS_Publication_PublicationCreation
GO
-- usp_STXDSS_Publication_PublicationCreation 'EAF_DATA2',1

CREATE PROCEDURE usp_STXDSS_Publication_PublicationCreation
@publicationName	VARCHAR(100),
@debugBit		BIT = 0 
AS

SET NOCOUNT ON 


DECLARE @SQLSentence  	NVARCHAR(3000)
DECLARE @indexName 	NVARCHAR(500)

SET @publicationName = upper(@publicationName)


--verifies if the location table exists , if not creates it 

if EXISTS
(
	SELECT 	name 
	FROM   	sysobjects 
	WHERE 	name = @publicationName
		AND 	  type = 'U'
)
BEGIN 
	SET @SQLSentence = ' 
	DROP TABLE ' + @publicationName
	exec sp_executesql @SQLSentence 
	IF @debugBit =1 
	BEGIN
		PRINT '******************************************************************************************'
		PRINT 'PREVIOUS table of  ' + @publicationName + '  was DELETED !!!! '
		PRINT '******************************************************************************************'
	END 	
END 



		
SET @SQLSentence = ' 
CREATE TABLE ' + @publicationName + '
(
	rowID		nvarchar(50) 
			not null,
	datetime	datetime 
			default GETDATE() NOT NULL,
	dataname	nvarchar(50) 
			not null,
	dataType	nvarchar(25) 
			not null,
	value		nvarchar(3000) 
			not null,
	isDataReset	bit	
			default 0
	
)'
--creates the table executoing the sql sentence 
if @debugBit = 1 	
BEGIN
	PRINT '******************************************************************************************'
	PRINT @SQLSentence
	PRINT '******************************************************************************************'
	
END 

exec sp_executesql @SQLSentence 

if @debugBit = 1 	
BEGIN
	PRINT '******************************************************************************************'
	PRINT 'Table ' + @publicationName + ' CREATED '
	PRINT '******************************************************************************************'
	
END 


--creates an index into the Date Colum for faster data searching 
SET @indexName = 'id_' + @publicationName + '_datetime'
SET @SQLSentence = 'CREATE CLUSTERED INDEX ' + @indexName + '
					ON  ' + @publicationName + '(datetime)'
if @debugBit = 1 	
BEGIN
	PRINT '******************************************************************************************'
	PRINT 'INDEX OF TABLE ' + @publicationName + ' WAS CREATED'
	PRINT @SQLSentence
	PRINT '******************************************************************************************'
	
END 

	
exec sp_executesql @SQLSentence 


GO 
