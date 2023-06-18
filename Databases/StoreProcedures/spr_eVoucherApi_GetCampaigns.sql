IF EXISTS (
       SELECT *
       FROM   dbo.sysobjects
       WHERE  ID = OBJECT_ID(N'[dbo].[spr_eVoucherApi_GetCampaigns]')
              AND OBJECTPROPERTY(id, N'IsProcedure') = 1
   )
    DROP PROCEDURE [dbo].[spr_eVoucherApi_GetCampaigns]
GO
/*
	Created By		:	Tu Nguyen
	Created Date	:	Apr 28, 2023
	Description		:	Get Users

*/
CREATE PROCEDURE [dbo].[spr_eVoucherApi_GetCampaigns]
AS
BEGIN
	SET NOCOUNT ON  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  

	SELECT c.ID, c.Name, c.Description, c.Image, c.StartedDate, c.ExpiredDate,  c.CreatedDate, u.UserName,  pc.Partner_ID_FK PartnerId
	INTO #Campaign_Temp
	FROM Campaign c
	JOIN [User] u ON u.ID = c.CreatedBy
	JOIN PartnerCampaign pc ON pc.Campaign_ID_FK = c.ID
	
	SELECT *
	FROM #Campaign_Temp

	SELECT p.ID, P.CompanyName, p.Type,  p.CompanyEmailAddress, p.CompanyPhone, P.User_ID_FK
	FROM [Partner] p
	JOIN #Campaign_Temp c ON c.PartnerId = p.ID
	ORDER BY p.Type

	SELECT u.ID UserId, a.City, a.Street, a.Country, a.District
	FROM [User] u 
	JOIN [Address] a ON a.User_ID_FK = u.ID

	SELECT cg.Campaign_ID_FK CampaignID, g.*
	FROM CampaignGame cg
	JOIN #Campaign_Temp c ON c.ID = cg.Campaign_ID_FK
	JOIN Game g ON g.ID = cg.Game_ID_FK

	SET NOCOUNT OFF  
END


