CREATE PROCEDURE GetUser   
    @id int   
AS   
    SET NOCOUNT ON;  
    SELECT 
		id,
		userName,
		birthday,
		imgId 
    FROM [Users]
    WHERE id = @id;
	
    SELECT 
		id,
		title 
    FROM [Awards]
	JOIN [UserAward] ON [awardId] = id
    WHERE userId = @id;