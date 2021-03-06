﻿using System;

namespace Sun.DatingApp.Model.System.Menus.Dto
{
    public class PageEditDto
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string TagColor { get; set; }

        public string Icon { get; set; }

        public string Intro { get; set; }

        public int Order { get; set; }

        public Guid MenuId { get; set; }
    }
}
