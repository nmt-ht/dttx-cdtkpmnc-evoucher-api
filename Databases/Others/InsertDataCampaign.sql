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


select *  from Campaign
