IF EXISTS (
       SELECT *
       FROM   dbo.sysobjects
       WHERE  ID = OBJECT_ID(N'[dbo].[spr_eVoucherApi_Report_GetVoucherByCampaignID]')
              AND OBJECTPROPERTY(id, N'IsProcedure') = 1
   )
    DROP PROCEDURE [dbo].[spr_eVoucherApi_Report_GetVoucherByCampaignID]
GO
/*
	Created By		:	Tu Nguyen
	Created Date	:	Apr 28, 2023
	Description		:	Get Users

*/
CREATE PROCEDURE [dbo].[spr_eVoucherApi_Report_GetVoucherByCampaignID]
(
	@CampaignID UNIQUEIDENTIFIER = NULL
)
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	
	SELECT c.Name, Voucher.TotalVoucher
	FROM CampaignUser cu
	JOIN Campaign c ON c.ID = cu.Campaign_ID_FK
	OUTER APPLY(
		SELECT COUNT(1) TotalVoucher
		FROM Voucher v 
		WHERE v.User_ID_FK = cu.User_ID_FK
	) as Voucher
	WHERE (@CampaignID IS NULL OR C.ID = @CampaignID)

	SET NOCOUNT OFF
END