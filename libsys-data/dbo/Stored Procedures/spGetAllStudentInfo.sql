﻿CREATE PROCEDURE [dbo].[spGetAllStudentInfo]

AS
BEGIN
	SET NOCOUNT ON

	SELECT *
	FROM dbo.Students
	ORDER BY Id
	DESC
END