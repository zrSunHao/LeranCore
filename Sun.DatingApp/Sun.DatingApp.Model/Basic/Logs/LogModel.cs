using System;
using System.Collections.Generic;

namespace Sun.DatingApp.Model.Basic.Logs
{
    public class LogModel
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public List<string> Tags { get; set; } 

        public DateTime Datetime { get; set; }
        
        public List<string> Types { get; set; }

        public bool Read { get; set; }
    }
}
