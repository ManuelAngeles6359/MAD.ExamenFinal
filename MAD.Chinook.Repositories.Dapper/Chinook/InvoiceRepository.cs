﻿using Dapper;
using MAD.Chinook.Models;
using MAD.Chinook.Repositories.Chinook;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MAD.Chinook.Repositories.Dapper.Chinook
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(string connectionString) : base(connectionString)
        {
        }

        public int Count()
        {
            using (var connection = new
           SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>("SELECT Count(InvoiceId) FROM dbo.Invoice");
            }
        }

        public IEnumerable<Invoice> PagedList(int startRow, int endRow)
        {
            if (startRow >= endRow) return new List<Invoice>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@startRow", startRow);
                parameters.Add("@endRow", endRow);

                return connection.Query<Invoice>("dbo.InvoicePagedList",
                        parameters,
                        commandType:
                        System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
