using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sun.DatingApp.Utility.Dapper
{
    public interface IDapperContext : IDisposable
    {
        IDbConnection Conn { get; }
        void InitConnection();
        bool Committed { get; set; }
        void BeginTran();
        void Commit();
        void Rollback();
    }
}
