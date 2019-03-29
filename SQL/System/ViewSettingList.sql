
/****** Object:  View [dbo].[ViewSettingList]    Script Date: 2019/3/29 11:15:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewSettingList] AS SELECT
dbo.SystemSetting.Id,
dbo.SystemSetting.[Key],
dbo.SystemSetting.[Value],
dbo.SystemSetting.CreatedById,
dbo.SystemSetting.CreatedAt,
dbo.SystemSetting.UpdatedById,
dbo.SystemSetting.UpdatedAt,
C.Nickname AS Creator,
U.Nickname AS Modifier

FROM
dbo.SystemSetting
LEFT JOIN dbo.SystemAccount AS C ON dbo.SystemSetting.CreatedById = C.Id
LEFT JOIN dbo.SystemAccount AS U ON dbo.SystemSetting.UpdatedById = U.Id
WHERE
dbo.SystemSetting.Deleted = 0
GO


