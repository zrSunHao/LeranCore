using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sun.DatingApp.Model.Basic.Logs;

namespace Sun.DatingApp.Api.Controllers.Basic
{
    public class LogController : BaseController
    {
        [HttpGet("logs")]
        public IActionResult Logs()
        {
            var logs = new List<LogModel>();
            
            var log1 = new LogModel()
            {
                Id = Guid.NewGuid(),
                Text = "哈哈哈",
                Datetime = DateTime.Now,
                Tags = new List<string>() { "important" },
                Types = new List<string>() { "system", "alert" }
            };
            var log2 = new LogModel()
            {
                Id = Guid.NewGuid(),
                Text = "嘿嘿和",
                Datetime = DateTime.Now,
                Tags = new List<string>() { "important" },
                Types = new List<string>() { "system", "alert" }
            };
            var log3 = new LogModel()
            {
                Id = Guid.NewGuid(),
                Text = "呵呵呵",
                Datetime = DateTime.Now,
                Tags = new List<string>() { "important" },
                Types = new List<string>() { "system", "alert" },
                Read = true
            };
            logs.Add(log1);
            logs.Add(log2);
            logs.Add(log3);

            return new JsonResult(logs);
        }
    }
}