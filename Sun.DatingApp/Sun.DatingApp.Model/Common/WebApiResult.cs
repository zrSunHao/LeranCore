using System;
using System.Collections.Generic;

namespace Sun.DatingApp.Model.Common
{
    public class WebApiResult<T>
    {
        public virtual T Data { get; set; }

        public virtual bool HasErrors
        {
            get
            {
                return this.Messages.Count > 0;
            }
            set
            {
            }
        }

        public virtual bool Success
        {
            get
            {
                return !this.HasErrors;
            }
            set
            {
            }
        }

        public virtual string AllMessages
        {
            get
            {
                return string.Join(Environment.NewLine, this.Messages.ToArray());
            }
            set
            {
            }
        }

        public virtual List<Exception> Errors { get; set; }

        public virtual List<string> Messages { get; set; }

        public WebApiResult()
        {
            this.Errors = new List<Exception>();
            this.Messages = new List<string>();
        }

        public WebApiResult(WebApiResult<T> source)
        {
            this.Errors = source.Errors;
            this.Messages = source.Messages;
            this.Data = source.Data;
        }

        public virtual void AddError(string error)
        {
            this.AddError(new Exception(error));
        }

        public virtual void AddError(Exception error)
        {
            this.Errors.Add(error);
            this.Messages.Add(error.Message);
        }
    }

    public class WebApiResult : WebApiResult<bool>
    {
        public override bool Data
        {
            get
            {
                return this.Success;
            }
            set
            {
            }
        }
    }
}
