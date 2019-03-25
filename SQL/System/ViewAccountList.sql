SELECT
	dbo.SystemAccount.Id,
	dbo.SystemAccount.Email,
	dbo.SystemAccount.Nickname,
	dbo.SystemAccount.Mobile,
	dbo.SystemAccount.Active,
	dbo.SystemAccount.LatestLoginAt,
	dbo.SystemAccount.Forbiden,
	dbo.SystemAccount.LockoutEndAt,
	dbo.SystemAccount.AccessFailedCount,
	dbo.SystemAccount.CreatedAt,
	dbo.SystemAccount.UpdatedAt,
	dbo.SystemRole.Id AS RoleId,
	dbo.SystemRole.Name AS RoleName,
	dbo.SystemRole.Rank AS RoleRank,
	dbo.SystemRole.Active AS RoleActive,
	(
SELECT TOP
	1 dbo.SystemAccountAvatar.Url 
FROM
	dbo.SystemAccountAvatar 
WHERE
	dbo.SystemAccountAvatar.AccountId = dbo.SystemAccount.Id 
ORDER BY
	[CreatedAt] DESC 
	) AS AvatarUrl 
FROM
	dbo.SystemAccount
	INNER JOIN dbo.SystemRole ON dbo.SystemAccount.RoleId = dbo.SystemRole.Id 
WHERE
	dbo.SystemAccount.Deleted = 0