ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username, [Password], ProfilePicture, IsDeleted) VALUES
('someuser', 'somepass', NULL, 1)

SELECT * FROM Users