DECLARE @user UNIQUEIDENTIFIER = '9A44F2C1-6413-432F-A917-04BC1E2AF859'
INSERT INTO Campaign(	ID,	Name,[Description],CreatedDate,StartedDate,ExpiredDate,ModifiedDate,CreatedBy,ModifiedBy,IsDeleted)
values 
	( NEWID(), 'Hoi cho thuong mai', 'Nhan ma giam gia 20% khi tham gia chuong trinh', GETDATE(), GETDATE(), GETDATE(),
       GETDATE(), @user, @user, 0),
	   ( NEWID(), 'Mua mot tang mot', 'Mua mot kem chong nang duoc tang kem sua rua mat', GETDATE(), GETDATE(), GETDATE(),
       GETDATE(), @user, @user, 0),
	   ( NEWID(), 'Ngay hoi gia dinh', 'Khuyen mai 10 %', GETDATE(), GETDATE(), GETDATE(),
       GETDATE(), @user, @user, 0),
	   ( NEWID(), 'Chia se va tuong tac', '10 luot chia se nhan voucher khuyen mai 10%', GETDATE(), GETDATE(), GETDATE(),
       GETDATE(), @user, @user, 0),
	   ( NEWID(), 'Thang khuyen mai', 'Khuyen mai dau nam', GETDATE(), GETDATE(), GETDATE(),
       GETDATE(), @user, @user, 0),
	( NEWID(), 'Chao don thanh vien moi', 'Nhan ma giam gia 20% khi dang ki the thanh vien', GETDATE(), GETDATE(), GETDATE(),
       GETDATE(), @user, @user, 0), 
	( NEWID(), 'Chuong trinh khach hang than thiet', 'Mung sinh nhat shop, gui tang quy khach hang than thiet nhieu ma giam hap dan', GETDATE(), GETDATE(), GETDATE(),
       GETDATE(), @user, @user, 0 ),
	( NEWID(), 'Sale ngay 5/5', 'Chao mung ban den voi the gioi thuong hieu', GETDATE(), GETDATE(), GETDATE(),
       GETDATE(), @user, @user, 0),  
	( NEWID(), 'Ngay hoi dau nam', 'Sale lon dau nam', GETDATE(), GETDATE(), GETDATE(),
       GETDATE(), @user, @user, 0), 
	( NEWID(), 'Tang doanh so', 'Mua mot tang mot', GETDATE(), GETDATE(), GETDATE(),
       GETDATE(), @user, @user, 0) 

Insert into Game( ID, Name, [Description], CreatedDate, ModifiedDate, CreatedBy, ModifiedBy,   IsDeleted)
Values (NewID(),'Co vua','Tro choi tri tue', GETDATE(), GETDATE(), @user
	, @user, 0), 
	(NewID(),'Candy Crush','Tro choi giai tri', GETDATE(), GETDATE(), @user
	, @user, 0), 
	(NewID(),'Ban cung','Su dung cung va ten den ban vao muc tieu', GETDATE(), GETDATE(), @user
	, @user, 0), 
	(NewID(),'Dua xe','Tro choi giai tri', GETDATE(), GETDATE(), @user
	, @user, 0)


DECLARE @Campaign1 UNIQUEIDENTIFIER = '715AC80E-F58A-44F6-88EB-0F01881D5DE9'
DECLARE @Campaign2 UNIQUEIDENTIFIER = 'E8136799-5D0F-4488-B07F-4C90EEF8BB9D'
DECLARE @Campaign3 UNIQUEIDENTIFIER = 'AF84059F-8936-46D2-B800-699FCA010895'
DECLARE @Game1 UNIQUEIDENTIFIER = '823FD993-9FFA-4CFE-BEB5-823125E13D7C'
DECLARE @Game2 UNIQUEIDENTIFIER = 'FBA99FEF-A137-46DA-98C9-A8BF66DB3194'
DECLARE @Game3 UNIQUEIDENTIFIER = '60F251DB-8FAE-4B56-9E94-C689742592DD'
DECLARE @Game4 UNIQUEIDENTIFIER = '21A1D762-541F-4D2C-B416-DDBA35D16E52'

insert into CampaignGame(ID, Campaign_ID_FK, Game_ID_FK)
values (NewID(),@Campaign1,@Game1),
		(NewID(),@Campaign1,@Game2),
		(NewID(),@Campaign1,@Game3),
		(NewID(),@Campaign1,@Game4),
		(NewID(),@Campaign2,@Game1),
		(NewID(),@Campaign2,@Game2),
		(NewID(),@Campaign2,@Game3),
		(NewID(),@Campaign2,@Game4),
		(NewID(),@Campaign3,@Game1),
		(NewID(),@Campaign3,@Game2),
		(NewID(),@Campaign3,@Game3),
		(NewID(),@Campaign3,@Game4)