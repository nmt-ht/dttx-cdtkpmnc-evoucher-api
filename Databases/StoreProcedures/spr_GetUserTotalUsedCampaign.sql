drop PROCEDURE  [dbo].[spr_GetUserTotalUsedCampaign] 
 
CREATE PROCEDURE [dbo].[spr_GetUserTotalUsedCampaign] 
AS
BEGIN
	SET NOCOUNT ON  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  

	select Campaign.ID,Description,Name, COUNT(User_ID_FK) UserTotal
	from Campaign 
	left join CampaignUser on Campaign.ID=CampaignUser.Campaign_ID_FK
	group by Campaign.ID,Description,Name

	SET NOCOUNT OFF  
END
EXEC  [dbo].[spr_GetUserTotalUsedCampaign] 
