/*
	CREATE TEST DATA FOR Partner
*/

TRUNCATE TABLE [Partner]

DECLARE @UserTest_1 UNIQUEIDENTIFIER = (SELECT ID FROM [User] WHERE UserName='tu.nguyen')

INSERT INTO Partner(ID, User_ID_FK, CompanyName, Description, CompanyEmailAddress, CompanyPhone, JoinDate, Type, IsActive)
VALUES(NEWID(), @UserTest_1, 'NThe coffee motel', N'Chuỗi cung ứng cà phê bán lẻ lớn nhất Quận 9', 'coffeemotel@gmail.com', '0234568989', GETDATE()-10, 1, 1)


DECLARE @UserTest_2 UNIQUEIDENTIFIER = (SELECT ID FROM [User] WHERE UserName='hieu.le')

INSERT INTO Partner(ID, User_ID_FK, CompanyName, Description, CompanyEmailAddress, CompanyPhone, JoinDate, Type, IsActive)
VALUES(NEWID(), @UserTest_2, N'HIEU group', N'Chuỗi nhà hàng khách sạn luxury Gò Vấp', 'hieugroup@gmail.com', '0234568966', GETDATE()-10, 1, 1)


DECLARE @UserTest_3 UNIQUEIDENTIFIER = (SELECT ID FROM [User] WHERE UserName='thu.nguyen')

INSERT INTO Partner(ID, User_ID_FK, CompanyName, Description, CompanyEmailAddress, CompanyPhone, JoinDate, Type, IsActive)
VALUES(NEWID(), @UserTest_3, N'Cô ba Bánh khọt', N'Cung cấp những chiếc bánh khọt toàn thành phố HCM', 'co3khot@gmail.com', '0234568911', GETDATE()-10, 1, 1)


DECLARE @UserTest_4 UNIQUEIDENTIFIER = (SELECT ID FROM [User] WHERE UserName='than.tran')

INSERT INTO Partner(ID, User_ID_FK, CompanyName, Description, CompanyEmailAddress, CompanyPhone, JoinDate, Type, IsActive)
VALUES(NEWID(), @UserTest_4, N'Cô Năm bánh bèo', N'Sỉ lẻ bánh bèo toàn địa bàn Bình Thạnh, Gò Vấp', 'co5beo@gmail.com', '0234568922', GETDATE()-10, 1, 1)


DECLARE @UserTest_5 UNIQUEIDENTIFIER = (SELECT ID FROM [User] WHERE UserName='hung.nguyen')

INSERT INTO Partner(ID, User_ID_FK, CompanyName, Description, CompanyEmailAddress, CompanyPhone, JoinDate, Type, IsActive)
VALUES(NEWID(), @UserTest_5, N'The coffee shop', N'Chuỗi cung ứng cà phê bán lẻ lớn nhất HCM', 'coffeeshop@gmail.com', '0234568989', GETDATE()-10, 1, 1)


DECLARE @UserTest_6 UNIQUEIDENTIFIER = (SELECT ID FROM [User] WHERE UserName='vuong.pham')

INSERT INTO Partner(ID, User_ID_FK, CompanyName, Description, CompanyEmailAddress, CompanyPhone, JoinDate, Type, IsActive)
VALUES(NEWID(), @UserTest_6, N'Vuong TECH', N'Chuyên cung cấp laptop, PC và phụ kiện máy tính', 'vuongtech@gmail.com', '0234568900', GETDATE()-10, 1, 1)


DECLARE @UserTest_7 UNIQUEIDENTIFIER = (SELECT ID FROM [User] WHERE UserName='tai.le')

INSERT INTO Partner(ID, User_ID_FK, CompanyName, Description, CompanyEmailAddress, CompanyPhone, JoinDate, Type, IsActive)
VALUES(NEWID(), @UserTest_7, N'Rau má 9999', N'Chuỗi cung ứng bán lẻ rau má', 'rauma9999@gmail.com', '0234568933', GETDATE()-10, 1, 1)