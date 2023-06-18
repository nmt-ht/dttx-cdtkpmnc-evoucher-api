IF EXISTS (
       SELECT *
       FROM   dbo.sysobjects
       WHERE  ID = OBJECT_ID(N'[dbo].[spr_eVoucherApi_Report_GetCampaigns]')
              AND OBJECTPROPERTY(id, N'IsProcedure') = 1
   )
    DROP PROCEDURE [dbo].[spr_eVoucherApi_Report_GetCampaigns]
GO
/*
	Created By		:	Tu Nguyen
	Created Date	:	Apr 28, 2023
	Description		:	Get Users

*/
CREATE PROCEDURE [dbo].[spr_eVoucherApi_Report_GetCampaigns]
(
	@CreatedDateFrom DATETIME = NULL,
	@CreatedDateTo DATETIME = NULL
)
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	
	SELECT c.CreatedDate, COUNT(1) TotalCampaign
	FROM Campaign c
	WHERE 
		(@CreatedDateFrom IS NULL OR c.CreatedDate >= @CreatedDateFrom)
		AND 
		(@CreatedDateTo IS NULL OR c.CreatedDate <= @CreatedDateTo)
	GROUP BY c.CreatedDate
		
	SET NOCOUNT OFF
END