using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Common;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace api.Services
{
    public class Dapperr : IDapper
    {
        private readonly IConfiguration _config;
        public string ConnectionString { get; set; } = "DefaultConnection";

        private IDbTransaction? dbTransaction;

        public Dapperr(IConfiguration config)
        {
            _config = config;
        }



        public void Dispose()
        {
            
        }

        public DbConnection GetDbconnection()
        {
            throw new NotImplementedException();
        }


        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionString);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }

        public async Task<T> Execute<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionString);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return await connection.ExecuteScalarAsync<T>(sql, parameters);
            }
        }

        public string ReadSqlText(string sqlName)
        {
            //var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            StreamReader sr = new($"./Querys/{sqlName}", Encoding.GetEncoding("Shift_JIS"));
            string sqlText = sr.ReadToEnd();
            sr.Close();
            return sqlText;
        }

        

        public void BeginTran()
        {
            string connectionString = _config.GetConnectionString(ConnectionString);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                this.dbTransaction = connection.BeginTransaction();
            }
        }

        public void CommitTran()
        {
            if (this.dbTransaction != null)
            {
                this.dbTransaction.Commit();
                this.dbTransaction.Dispose();
            }
        }

        public void RollBackTran()
        {
            if (this.dbTransaction != null)
            {
                this.dbTransaction.Rollback();
                this.dbTransaction.Dispose();
            }
        }

        


    }
}