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
        }
    }
}
