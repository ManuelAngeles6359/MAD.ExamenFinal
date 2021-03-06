﻿using Dapper;
using MAD.Chinook.Models;
using MAD.Chinook.Repositories.Chinook;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MAD.Chinook.Repositories.Dapper.Chinook
{
    public class InvoiceLineRepository : Repository<InvoiceLine>, IInvoiceLineRepository
    {
        public InvoiceLineRepository(string connectionString) : base(connectionString)
        {
        }

        public int Count()
        {
            using (var connection = new
           SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>("SELECT Count(InvoiceLineId) FROM dbo.InvoiceLine");
            }
        }

        public IEnumerable<InvoiceLine> PagedList(int startRow, int endRow)
        {
            if (startRow >= endRow) return new List<InvoiceLine>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@startRow", startRow);
                parameters.Add("@endRow", endRow);

                return connection.Query<InvoiceLine>("dbo.InvoiceLinePagedList",
                        parameters,
                        commandType:
                        System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
