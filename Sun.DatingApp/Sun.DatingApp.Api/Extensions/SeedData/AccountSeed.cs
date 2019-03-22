using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Api.Extensions.SeedData
{
    public class AccountSeed
    {
        public static void Initialize(DataContext context)
        {
            Default(context);

            context.SaveChanges();
        }

        /// <summary>
        /// 添加默认账号
        /// </summary>
        /// <param name="context"></param>
        private static void Default(DataContext context)
        {
            var role = context.SystemRoles.FirstOrDefault();
            if (role == null) throw new Exception("系统角色信息为空，新建默认账号失败！");

            var account = new SystemAccount
            {
                Id = Guid.NewGuid(),
                Email = "2080680175@qq.com",
                Nickname = "系统超级管理员",
                Mobile = "17853711796",
                RoleId = role.Id,
                PasswordHash = null,//TODO
                PasswordSalt = null,//TODO
                RefreshToken = null,
                Active = true,
                Forbiden = false,
                AccessFailedCount = 0,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            var avatar = new SystemAccountAvatar()
            {
                AccountId = account.Id,
                FileLength = 68993,
                FileName = "默认头像",
                FileType = "image/jpeg",
                Url = "http://zeus-dev.oss-cn-qingdao.aliyuncs.com/2feb9e5b-1179-5e96-ecaf-db11347bd998.jpg",
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty
            };

            context.SystemAccounts.Add(account);
            context.SystemAccountAvatars.Add(avatar);
        }
    }
}
