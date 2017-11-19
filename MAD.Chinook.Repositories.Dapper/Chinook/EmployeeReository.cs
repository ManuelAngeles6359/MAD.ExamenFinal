﻿using Dapper;
using MAD.Chinook.Models;
using MAD.Chinook.Repositories.Chinook;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MAD.Chinook.Repositories.Dapper.Chinook
{
    public class EmployeeReository : Repository<Employee>, IEmployeeReository
    {
        public EmployeeReository(string connectionString) : base(connectionString)
        {
        }

        public int Count()
        {
            using (var connection = new
           SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>("SELECT Count(EmployeeId) FROM dbo.Employee");
            }
        }

        public IEnumerable<Employee> PagedList(int startRow, int endRow)
        {
            if (startRow >= endRow) return new List<Employee>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@startRow", startRow);
                parameters.Add("@endRow", endRow);

                return connection.Query<Employee>("dbo.EmployeePagedList",
                        parameters,
                        commandType:
                        System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
