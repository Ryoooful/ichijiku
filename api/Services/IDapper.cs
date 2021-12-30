using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public interface IDapper : IDisposable
    {
        DbConnection GetDbconnection();
        
        Task<string> LoadData<T>(string sql, T parameters);

        
        Task<T> Execute<T, U>(string sql, U parameters);
        
        void BeginTran();
        void CommitTran();
        void RollBackTran();
        string ReadSqlText(string sqlName);

    }
}