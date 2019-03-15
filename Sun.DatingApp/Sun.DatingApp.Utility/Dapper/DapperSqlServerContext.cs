using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Sun.DatingApp.Utility.Dapper
{
    public class DapperSqlServerContext : IDapperContext, IDisposable
    {
        private readonly string connStr = "";

        public DapperSqlServerContext()
        {
            InitConnection();
        }

        public IDbConnection Conn { private set; get; }

        public void InitConnection()
        {
            Conn = new SqlConnection(connStr);
        }

        private readonly object _sync = new object();

        public bool Committed { get; set; }

        public IDbTransaction Tran { private set; get; }

        public void BeginTran()
        {
            if (this.Conn.State != ConnectionState.Open)
            {
                this.Conn.Open();
            }
            this.Tran = this.Conn.BeginTransaction();
            this.Committed = false;
        }

        public void Commit()
        {
            if (this.Conn.State != ConnectionState.Open)
            {
                this.Conn.Open();
            }
            lock (_sync)
            {
                Tran.Commit();
                Committed = true;
            }
        }

        public void Rollback()
        {
            if (this.Conn.State != ConnectionState.Open)
            {
                this.Conn.Open();
            }
            lock (_sync)
            {
                Tran.Rollback();
                Committed = false;
            }
        }

        public void Dispose()
        {
            if (this.Conn.State != ConnectionState.Open) return;
            Commit();
            this.Conn.Close();
            this.Conn.Dispose();
        }
    }
}
