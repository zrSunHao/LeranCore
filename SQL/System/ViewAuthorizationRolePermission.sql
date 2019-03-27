
GO

/****** Object:  View [dbo].[ViewAuthorizationRolePermission]    Script Date: 2019/3/27 17:40:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewAuthorizationRolePermission] AS SELECT
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
GO


