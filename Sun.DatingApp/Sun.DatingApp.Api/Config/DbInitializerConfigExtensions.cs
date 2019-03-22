using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sun.DatingApp.Api.Extensions.SeedData;
using Sun.DatingApp.Data.Database;

namespace Sun.DatingApp.Api.Config
{
    public class DbInitializerConfigExtensions
    {
        /// <summary>
        /// 首次部署的时候添加系统默认数据
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            var existAccount = context.SystemAccounts.Any();
            //存在账号说明不是初次使用，不初始化数据
            if (existAccount) return;

            //1.添加菜单 => 页面 => 权限信息
            MenuSeed.Initialize(context);

            //2.首先添加系统超级管理员
            RoleSeed.Initialize(context);

            //3.添加默认账号，角色默认为系统超级管理员
            AccountSeed.Initialize(context);
        }
    }
}
