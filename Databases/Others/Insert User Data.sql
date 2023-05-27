/*
	CREATE TEST DATA
		- User
		- User Group
		- User Group Link
*/

-- RESET DATA
/*
	DELETE Campaign
	DELETE [Address]
	DELETE UserGroupLink
	DELETE UserGroup
	DELETE [User]
*/

-- Admin user
DECLARE @AdminID UNIQUEIDENTIFIER = 'F04E7F87-EC67-4553-AC7B-0B3C33A97436' -- Default ID

INSERT INTO [User](ID, FirstName, LastName, DateOfBirth, EmailAddress, Phone, UserName, Password, IsActive)
VALUES(@AdminID, 'Admin', 'Admin', GETDATE()-(20*365), 'admin@gmai.com', '0972345987', 'admin', 'admin', 1)

INSERT INTO [Address](ID, Street, District, City, Country, Type, IsDeleted, User_ID_FK)
VALUES(NEWID(), N'227 Đ. Nguyễn Văn Cừ, Phường 4', N'Quận 5', N'Thành phồ Hồ Chí Minh', N'Việt Nam', 1, 1, @AdminID)

-- Test user
INSERT INTO [User](ID, FirstName, LastName, DateOfBirth, EmailAddress, Phone, UserName, Password, IsActive)
VALUES
	(NEWID(), 'Tu', 'Nguyen', GETDATE()-(20*365), 'tu@gmai.com', '0972345987', 'tu.nguyen', '12345678', 1),
	(NEWID(), 'Hieu', 'Le', GETDATE()-(20*365), 'hieu@gmai.com', '0972345988', 'hieu.le', '12345678', 1),
	(NEWID(), 'Thu', 'Nguyen', GETDATE()-(20*365), 'thu@gmai.com', '0972345989', 'thu.nguyen', '12345678', 1),
	(NEWID(), 'Than', 'Tran', GETDATE()-(20*365), 'than@gmai.com', '0972345990', 'than.tran', '12345678', 1),
	(NEWID(), 'Hung', 'Nguyen', GETDATE()-(20*365), 'than@gmai.com', '0972345990', 'hung.nguyen', '12345678', 1),
	(NEWID(), 'Vinh', 'Tran', GETDATE()-(20*365), 'than@gmai.com', '0972345990', 'vinh.tran', '12345678', 1),
	(NEWID(), 'Tham', 'Vuong', GETDATE()-(20*365), 'than@gmai.com', '0972345990', 'tham.vuong', '12345678', 1),
	(NEWID(), 'Nhat', 'Tran', GETDATE()-(20*365), 'than@gmai.com', '0972345990', 'nhat.tran', '12345678', 1),
	(NEWID(), 'Tai', 'Le', GETDATE()-(20*365), 'than@gmai.com', '0972345990', 'tai.le', '12345678', 1),
	(NEWID(), 'Vuong', 'Pham', GETDATE()-(20*365), 'than@gmai.com', '0972345990', 'vuong.pham', '12345678', 1),
	(NEWID(), 'Phu', 'Hung', GETDATE()-(20*365), 'than@gmai.com', '0972345990', 'phu.hung', '12345678', 1)

DECLARE @UG_AdminID UNIQUEIDENTIFIER = 'A81288E2-096F-443F-B6D2-53E456A3DD56'
DECLARE @UG_PartnerID UNIQUEIDENTIFIER = '6D52C91B-E02A-4CE1-AB0B-B94ED3F96690'

INSERT INTO UserGroup(ID, Name, Description, IsActive)
VALUES
	(@UG_AdminID, 'Admin', 'Using for administrator', 1),
	(@UG_PartnerID, 'Partner', 'Using for partner', 1)

INSERT INTO UserGroupLink(ID, User_ID_FK, UserGroup_ID_FK)
VALUES(NEWID(), @AdminID, @UG_AdminID)
