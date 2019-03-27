
GO

/****** Object:  View [dbo].[ViewRolePageList]    Script Date: 2019/3/27 17:41:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewRolePageList] AS SELECT DISTINCT
dbo.SystemRolePermission.RoleId,
dbo.SystemRolePermission.PageId,
dbo.SystemPage.Name,
dbo.SystemPage.Url,
dbo.SystemPage.TagColor,
dbo.SystemPage.Icon,
dbo.SystemPage.Active,
dbo.SystemPage.Intro,
dbo.SystemPage.[Order],
dbo.SystemPage.MenuId

FROM
dbo.SystemRolePermission
INNER JOIN dbo.SystemPage ON dbo.SystemRolePermission.PageId = dbo.SystemPage.Id
WHERE
dbo.SystemRolePermission.Deleted = 0
GO


