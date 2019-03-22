using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sun.DatingApp.Data.Database;

namespace Sun.DatingApp.Api.Config
{
    public class DbInitializerConfigExtensions
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            var test = context.SystemAccounts.Any();
            var see = test;

            //添加模块信息

            //添加菜单信息

            //首先添加系统超级管理员

            //添加默认账号，角色默认为系统超级管理员
        }

        public static void AddModule(DataContext context)
        {

        }
    }
}
