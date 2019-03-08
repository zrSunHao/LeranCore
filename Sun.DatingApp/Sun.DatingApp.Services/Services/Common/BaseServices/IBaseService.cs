using System;

namespace Sun.DatingApp.Services.Services.Common.BaseServices
{
    public interface IBaseService
    {
        void SetCurrentUserId(Guid? id);
    }
}
