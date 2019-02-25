﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sun.DatingApp.Api.Extensions.Authorization
{
    public class Permissions
    {
        public const string Role = "Role";
        public const string RoleCreate = "Role.Create";
        public const string RoleRead = "Role.Read";
        public const string RoleUpdate = "Role.Update";
        public const string RoleDelete = "Role.Delete";

        public const string User = "User";
        public const string UserCreate = "User.Create";
        public const string UserRead = "User.Read";
        public const string UserUpdate = "User.Update";
        public const string UserDelete = "User.Delete";

        public const string Car = "Car";
        public const string CarRead = "Car.Read";
    }
}
