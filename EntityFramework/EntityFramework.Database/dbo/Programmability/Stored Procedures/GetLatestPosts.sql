CREATE PROCEDURE [dbo].[GetLatestPosts]
	@numPosts int
AS
	SELECT TOP (@numPosts) * FROM [dbo].[Posts]
	ORDER BY [Date] DESC
