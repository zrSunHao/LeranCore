SELECT
dbo.SystemRolePermission.RoleId,
dbo.SystemRolePermission.PermissionId AS PermissionId,
dbo.SystemPermission.Name AS PermissionName,
dbo.SystemPermission.Code AS PermissionCode,
dbo.SystemPermission.Active AS PermissionActive,
dbo.SystemPermission.Rank AS PermissionRank

FROM
dbo.SystemRolePermission
INNER JOIN dbo.SystemPermission ON dbo.SystemRolePermission.PermissionId = dbo.SystemPermission.Id
WHERE
dbo.SystemRolePermission.Deleted = 0 AND
dbo.SystemPermission.Deleted = 0