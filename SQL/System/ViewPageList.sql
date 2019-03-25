SELECT
dbo.SystemPage.Id,
dbo.SystemPage.Name,
dbo.SystemPage.Url,
dbo.SystemPage.TagColor,
dbo.SystemPage.Icon,
dbo.SystemPage.Intro,
dbo.SystemPage.Active,
dbo.SystemPage.[Order],
dbo.SystemPage.MenuId,
dbo.SystemMenu.Name AS MenuName,
dbo.SystemMenu.TagColor AS MenuTagColor,
dbo.SystemMenu.Icon AS MenuIcon,
dbo.SystemMenu.Active AS MenuActive,
dbo.SystemMenu.Intro AS MenuIntro,
dbo.SystemMenu.[Order] AS MenuOrder

FROM
dbo.SystemPage
INNER JOIN dbo.SystemMenu ON dbo.SystemPage.MenuId = dbo.SystemMenu.Id
WHERE
dbo.SystemMenu.Deleted = 0