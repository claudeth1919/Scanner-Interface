-- creating the store procedure
IF EXISTS 
(
	SELECT 	name 
	FROM   	sysobjects 
	WHERE  	name = N'usp_STXDSS_Publication_PublicationDispose' 
	   	AND 	  type = 'P'
)
	DROP PROCEDURE  usp_STXDSS_Publication_PublicationDispose
GO
-- usp_STXDSS_Publication_PublicationDispose 'EAF_DATA2',1

CREATE PROCEDURE usp_STXDSS_Publication_PublicationDispose
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

	IF @debugBit = 1 
	BEGIN
	
		PRINT '****************************************************************************************************'
		PRINT ' PUBLICATION ' + @publicationName + ' table DISPOSED !!!!' 
		PRINT '****************************************************************************************************'
	
	END 

END
ELSE
BEGIN
	IF @debugBit = 1 
	BEGIN
	
		PRINT '****************************************************************************************************'
		PRINT ' PUBLICATION ' + @publicationName + ' NOT AVAILABLE OR NOT EXISTS !!!!' 
		PRINT '****************************************************************************************************'
	
	END 

END 


GO 
