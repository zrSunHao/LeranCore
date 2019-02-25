using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Services.Services.BaseServices
{
    public interface IBaseService
    {
        void SetCurrentUserId(Guid? id);
    }
}
