DECLARE @UserID UNIQUEIDENTIFIER = NEWID()

INSERT INTO [User](ID, FirstName, LastName, DateOfBirth, EmailAddress, Phone, UserName, Password, IsActive) 
VALUES(@UserID, 'tu', 'nguyen', GETDATE() - (365*20), 'tu.nguyen@gmail.com', '12345564', 'test_123', '123456', 1)

INSERT INTO Address(ID, Street, District, City, Country, Type, IsDeleted, User_ID_FK)
VALUES(NEWID(), 'HBT', 'Quan 1', 'Ho Chi Minh', 'Viet Nam', 1, 0, @UserID)
