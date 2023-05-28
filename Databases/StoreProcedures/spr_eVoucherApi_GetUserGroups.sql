IF EXISTS (
       SELECT *
       FROM   dbo.sysobjects
       WHERE  ID = OBJECT_ID(N'[dbo].[spr_eVoucherApi_GetUserGroups]')
              AND OBJECTPROPERTY(id, N'IsProcedure') = 1
   )
    DROP PROCEDURE [dbo].[spr_eVoucherApi_GetUserGroups]
GO
/*
	Created By		:	Tu Nguyen
	Created Date	:	Apr 28, 2023
	Description		:	Get Users

*/
CREATE PROCEDURE [dbo].[spr_eVoucherApi_GetUserGroups]
AS
BEGIN
	SET NOCOUNT ON  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  

	SELECT *
	FROM [UserGroup] u
	WHERE u.IsActive = 1

	SET NOCOUNT OFF  
END
