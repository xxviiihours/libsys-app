﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_api_library.Internal.DataAccess
{
    internal class SqlDataAccess
    {
        private readonly IConfiguration configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetConnectionString(string name)
        {
            return configuration.GetConnectionString(name);
            //return ConfigurationManager.ConnectionStrings[name].ConnectionString;

        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName) 
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }

        public void UpdateData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
               connection.Execute(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);
            }

        }

        public void DeleteData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }
    }
}
