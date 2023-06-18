CREATE PROC  [dbo].[spr_GetAllCampaign] 
(
	@CreatedDateFrom smalldatetime=NULL,
	@CreatedDateTo smalldatetime=NULL,
	@PartnerID UNIQUEIDENTIFIER=NULL

)
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	
	SELECT c.ID, c.Name, c.[Description], c.CreatedDate, c.StartedDate, c.ExpiredDate,
		   c.ModifiedDate, c.CreatedBy, c.ModifiedBy, c.IsDeleted,c.Image,pc.Partner_ID_FK
	FROM Campaign c
	LEFT JOIN PartnerCampaign pc ON pc.Campaign_ID_FK = c.ID
	WHERE c.CreatedDate >= @CreatedDateFrom AND c.CreatedDate <=@CreatedDateTo AND pc.Partner_ID_FK=@PartnerID
	
	SET NOCOUNT OFF
END





