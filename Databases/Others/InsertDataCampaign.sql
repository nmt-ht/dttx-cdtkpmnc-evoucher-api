DELETE FROM CampaignGame
DELETE FROM Game
DELETE FROM Campaign

-- Campaign
declare @User UNIQUEIDENTIFIER = (select top 1 ID from [user] WHERE UserName = 'Admin')

insert into Campaign (ID, Name, Description,CreatedDate,StartedDate,ExpiredDate,ModifiedDate, CreatedBy,ModifiedBy,IsDeleted)
values (NEWID(),N'Freeship 20.000',N'Ăn uống thả ga, FreeShip tới 20.000', GETDATE(),GETDATE(),GETDATE(),GETDATE(),@User,@User,0),
(NEWID(),N'Siêu deal 50%',N'Siêu deal giữa năm giảm 50%', GETDATE(),GETDATE(),GETDATE(),GETDATE(),@User,@User,0),
(NEWID(),N'Giảm 99.000đ',N'Chợ online - Sale giảm đỉnh 99.000đ', GETDATE(),GETDATE(),GETDATE(),GETDATE(),@User,@User,0),
(NEWID(),N'Giảm dến 40.000đ',N'Chợ tươi đầu tháng, giảm 40.000đ', GETDATE(),GETDATE(),GETDATE(),GETDATE(),@User,@User,0),
(NEWID(),N'Bão món deal 0d',N'Triệu món ngon, bão món deal 0d', GETDATE(),GETDATE(),GETDATE(),GETDATE(),@User,@User,0),
(NEWID(),N'Giảm tới 166.000đ',N'Tiệc linh đình giảm tới 166.000đ', GETDATE(),GETDATE(),GETDATE(),GETDATE(),@User,@User,0),
(NEWID(),N'Giảm 50.000đ',N'Vạn món giá hời, giảm 50.000đ', GETDATE(),GETDATE(),GETDATE(),GETDATE(),@User,@User,0),
(NEWID(),N'Giảm 50%',N'Quán mới lên sàn - Giảm 50%', GETDATE(),GETDATE(),GETDATE(),GETDATE(),@User,@User,0),
(NEWID(),N'Cuoi tuan no ne chot deal 0d',N'Quan moi len san, mon ngon deal 0d ngap tran', GETDATE(),GETDATE(),GETDATE(),GETDATE(),@User,@User,0),
(NEWID(),N'FreeShip tới 35.000đ',N'FreeShip tới 35.000đ', GETDATE(),GETDATE(),GETDATE(),GETDATE(),@User,@User,0)

-- Game
insert into Game(ID,Name,Description,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy,IsDeleted)
values (NEWID(),'Teris','Teris',GETDATE(),GETDATE(),@User,@User,0),
		(NEWID(),'TicTacToe','Tic Tac Toe',GETDATE(),GETDATE(),@User,@User,0),
		(NEWID(),'ConnectFour','ConnectFour',GETDATE(),GETDATE(),@User,@User,0)

-- CampaignGame
declare @Game1 UNIQUEIDENTIFIER = (select top 1 ID from Game WHERE Name = 'Teris')
declare @Game2 UNIQUEIDENTIFIER = (select top 1 ID from Game WHERE Name = 'TicTacToe')
declare @Game3 UNIQUEIDENTIFIER = (select top 1 ID from Game WHERE Name = 'ConnectFour')

insert into CampaignGame(ID,Campaign_ID_FK,Game_ID_FK)
values (NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Freeship 20.000'),@Game1),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Freeship 20.000'),@Game2),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Freeship 20.000'),@Game3),

		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Siêu deal 50%'),@Game1),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Siêu deal 50%'),@Game2),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Siêu deal 50%'),@Game3),

		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm 99.000đ'),@Game1),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm 99.000đ'),@Game2),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm 99.000đ'),@Game3),

		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm dến 40.000đ'),@Game1),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm dến 40.000đ'),@Game2),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm dến 40.000đ'),@Game3),

		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Bão món deal 0d'),@Game1),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Bão món deal 0d'),@Game2),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Bão món deal 0d'),@Game3),

		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm tới 166.000đ'),@Game1),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm tới 166.000đ'),@Game2),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm tới 166.000đ'),@Game3),

		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm 50.000đ'),@Game1),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm 50.000đ'),@Game2),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm 50.000đ'),@Game3),

		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm 50%'),@Game1),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm 50%'),@Game2),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Giảm 50%'),@Game3),

		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Cuoi tuan no ne chot deal 0d'),@Game1),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Cuoi tuan no ne chot deal 0d'),@Game2),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'Cuoi tuan no ne chot deal 0d'),@Game3),

		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'FreeShip tới 35.000đ'),@Game1),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'FreeShip tới 35.000đ'),@Game2),
		(NEWID(), (SELECT ID FROM Campaign WHERE Name=N'FreeShip tới 35.000đ'),@Game3)
