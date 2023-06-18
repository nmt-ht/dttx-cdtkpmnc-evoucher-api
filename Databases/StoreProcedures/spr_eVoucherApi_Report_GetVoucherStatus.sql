IF EXISTS (
       SELECT *
       FROM   dbo.sysobjects
       WHERE  ID = OBJECT_ID(N'[dbo].[spr_eVoucherApi_Report_GetVoucherStatus]')
              AND OBJECTPROPERTY(id, N'IsProcedure') = 1
   )
    DROP PROCEDURE [dbo].[spr_eVoucherApi_Report_GetVoucherStatus]
GO
/*
	Created By		:	Tu Nguyen
	Created Date	:	Apr 28, 2023
	Description		:	Get Users

*/
CREATE PROCEDURE [dbo].[spr_eVoucherApi_Report_GetVoucherStatus]
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	
	SELECT 'Voucher' [Name], COUNT(1) Total
	FROM Voucher v
	UNION ALL
	SELECT 'Voucher Used', COUNT(1) Total
	FROM VoucherUsed

	SET NOCOUNT OFF
END





