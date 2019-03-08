using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sun.DatingApp.Model.Basic.Messages;

namespace Sun.DatingApp.Api.Controllers.Basic
{
    public class MessageController : BaseController
    {
        [HttpGet("messages")]
        public IActionResult Messages()
        {
            var messages = new List<MessageModel>();

            var m1 = new MessageModel()
            {
                Id = Guid.NewGuid(),
                Type = "datetime",
                Text = "2:30PM"
            };
            var m2 = new MessageModel()
            {
                Id = Guid.NewGuid(),
                Type = "in",
                Pic = "./assets/app/media/img//users/user3.jpg",
                Username = "张三",
                Text = "都是月亮惹得祸"
            };
            var m3 = new MessageModel()
            {
                Id = Guid.NewGuid(),
                Pic = "./assets/app/media/img//users/user3.jpg",
                Type = "in",
                Text = "都是月亮惹得祸"
            };
            var m4 = new MessageModel()
            {
                Id = Guid.NewGuid(),
                Type = "out",
                Text = "都是月亮惹得祸"
            };
            messages.Add(m1);
            messages.Add(m2);
            messages.Add(m3);
            messages.Add(m4);

            return new JsonResult(messages);
        }
    }
}