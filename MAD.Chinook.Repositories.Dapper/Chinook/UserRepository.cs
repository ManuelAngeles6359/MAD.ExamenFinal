using Dapper;
using MAD.Chinook.Models;
using MAD.Chinook.Repositories.Chinook;
using System.Data.SqlClient;

namespace MAD.Chinook.Repositories.Dapper.Chinook
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public User ValidaterUser(string email, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                parameters.Add("@password", password);

                return connection.QueryFirstOrDefault<User>("dbo.ValidateUser",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);

            }
        }
    }
}
