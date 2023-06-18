IF EXISTS (
       SELECT *
       FROM   dbo.sysobjects
       WHERE  ID = OBJECT_ID(N'[dbo].[spr_eVoucherApi_GetUserVouchers]')
              AND OBJECTPROPERTY(id, N'IsProcedure') = 1
   )
    DROP PROCEDURE [dbo].[spr_eVoucherApi_GetUserVouchers]
GO
/*
	Created By		:	Tu Nguyen
	Created Date	:	Apr 28, 2023
	Description		:	Get User Vouchers

*/
CREATE PROCEDURE [dbo].[spr_eVoucherApi_GetUserVouchers] 
(
	@CurrentUserID UNIQUEIDENTIFIER = NULL
)
AS
BEGIN
	SET NOCOUNT ON  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  

	DECLARE @EmptyGuid UNIQUEIDENTIFIER = '00000000-0000-0000-0000-000000000000'

	SELECT v.Code VoucherCode, v.CreatedDate ReceivedDate, v.ExpiredDate, g.Name GameName, c.Name CampaignName
	FROM [User] u
	JOIN CampaignUser cu ON cu.User_ID_FK = u.ID
	JOIN Campaign c ON c.ID = cu.Campaign_ID_FK
	JOIN Voucher v ON v.User_ID_FK = u.ID
	JOIN Game g ON g.ID = v.Game_ID_FK
	WHERE U.ID = @CurrentUserID


	SET NOCOUNT OFF  
END


