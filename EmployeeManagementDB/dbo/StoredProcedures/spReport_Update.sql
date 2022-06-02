CREATE PROCEDURE [dbo].[spReport_Update]
	@Id int,
	@ReportText nvarchar(MAX),
	@ReportDate datetime

AS

BEGIN
	UPDATE	[dbo].[Report]
	SET		ReportText =  @ReportText,
			ReportDate = @ReportDate
	
	WHERE	Id = @Id

END
