using Npgsql;

namespace SQLdb
{
    public class SqlProvider
    {
        private const string ConnectionString = "Host=localhost;Username=andrey;Password=12345;Database=otus";

        public string? GetVersion()
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                
                var query = "SELECT version()";
                
                using (var command = new NpgsqlCommand(query, connection))
                {
                    return command.ExecuteScalar()?.ToString();
                }
            }
        }
    }
}