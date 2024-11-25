using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DatabaseConnection.Services
{
    public class DatabaseService
    {
        private string _connectionString = "Server=localhost;Database=biblioteka;User=root;Password=;";

        public MySqlConnection Connection()
        {
            return new MySqlConnection(_connectionString);
        }

        public async Task<DataTable> ExecuteQuery(string query)
        {
            using MySqlConnection connection = Connection();
            await connection.OpenAsync();
            using MySqlCommand command = new(query, connection);

            using var reader = await command.ExecuteReaderAsync();
            var table = new DataTable();
            table.Load(reader);
            return table;
        }

        public async Task<int> ExecuteNonQuery(string query)
        {
            using MySqlConnection connection = Connection();
            await connection.OpenAsync();
            using MySqlCommand command = new(query, connection);

            return await command.ExecuteNonQueryAsync();
        }
    }
}
