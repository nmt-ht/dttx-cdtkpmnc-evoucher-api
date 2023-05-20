IF EXISTS (
       SELECT *
       FROM   dbo.sysobjects
       WHERE  ID = OBJECT_ID(N'[dbo].[spr_eVoucherApi_GetPartners]')
              AND OBJECTPROPERTY(id, N'IsProcedure') = 1
   )
    DROP PROCEDURE [dbo].[spr_eVoucherApi_GetPartners]
GO
/*
	Created By		:	Tu Nguyen
	Created Date	:	Apr 28, 2023
	Description		:	Get Users

*/
CREATE PROCEDURE [dbo].[spr_eVoucherApi_GetPartners] 
AS
BEGIN
	SET NOCOUNT ON  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  

	DECLARE @EmptyGuid UNIQUEIDENTIFIER = '00000000-0000-0000-0000-000000000000'

	SELECT *
	FROM [Partner]


	SET NOCOUNT OFF  
END
