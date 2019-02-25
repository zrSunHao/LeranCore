using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Messages
{
    public class MessageModel
    {
        
        public Guid Id { get; set; }
        
        public string Type { get; set; }
        
        public string Pic { get; set; }

        public string Username { get; set; }

        public string Text { get; set; }
    }
}
