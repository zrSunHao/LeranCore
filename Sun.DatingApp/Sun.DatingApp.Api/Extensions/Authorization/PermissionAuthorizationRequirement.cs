using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Sun.DatingApp.Api.Extensions.Authorization
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public PermissionAuthorizationRequirement(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
    }
}
