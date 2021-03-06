﻿using Dapper;
using MAD.Chinook.Models;
using MAD.Chinook.Repositories.Chinook;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MAD.Chinook.Repositories.Dapper.Chinook
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(string connectionString) : base(connectionString)
        {
        }

        public int Count()
        {
            using (var connection = new
           SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>("SELECT Count(PlaylistId) FROM dbo.Playlist");
            }
        }

        public IEnumerable<Playlist> PagedList(int startRow, int endRow)
        {
            if (startRow >= endRow) return new List<Playlist>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@startRow", startRow);
                parameters.Add("@endRow", endRow);

                return connection.Query<Playlist>("dbo.PlaylistPagedList",
                        parameters,
                        commandType:
                        System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
