SELECT DISTINCT 

dbo.SystemRolePermission.RoleId,
dbo.SystemRolePermission.PageId,
dbo.SystemPage.Name,
dbo.SystemPage.Url,
dbo.SystemPage.TagColor,
dbo.SystemPage.Icon,
dbo.SystemPage.Active,
dbo.SystemPage.Intro,
dbo.SystemPage.[Order]

FROM
dbo.SystemRolePermission
INNER JOIN dbo.SystemPage ON dbo.SystemRolePermission.PageId = dbo.SystemPage.Id
WHERE
dbo.SystemRolePermission.Deleted = 0