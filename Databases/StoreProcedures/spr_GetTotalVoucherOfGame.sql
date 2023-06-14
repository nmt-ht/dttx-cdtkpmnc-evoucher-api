drop PROCEDURE  [dbo].[spr_GetTotalVoucherOfGame] 
 
CREATE PROCEDURE [dbo].[spr_GetTotalVoucherOfGame] 
AS
BEGIN
	SET NOCOUNT ON  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED  

	select Game.ID, Game.Name, Game.Description, Count(Voucher.ID) VoucherTotal
	from  Game
	left join Voucher on Game.ID=Voucher.Game_ID_FK
	group by Game.ID, Game.Name, Game.Description
	SET NOCOUNT OFF  
END
EXEC  [dbo].[spr_GetTotalGameOfVoucher] 
