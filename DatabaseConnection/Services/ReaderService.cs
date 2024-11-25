using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DatabaseConnection.Model;

namespace DatabaseConnection.Services
{
    public class ReaderService
    {
        private readonly DatabaseService databaseService;

        public ReaderService(DatabaseService databaseService) => this.databaseService = databaseService;

        public async Task<List<Reader>> GetReaders()
        {
            List<Reader> readers = [];

            var table = await databaseService.ExecuteQuery("SELECT * FROM czytelnicy");
            foreach (DataRow row in table.Rows)
            {
                readers.Add(new Reader
                {
                    Id = Convert.ToInt32(row["id_autor"]),
                    Name = row["imie"].ToString(),
                    Surname = row["nazwisko"].ToString(),
                    Address = row["adres_zamieszkania"].ToString(),
                    Birthdate = row["data_urodzenia"].ToString(),
                    Number = (long)Convert.ToInt64(row["numer_telefonu"]),
                    EmailAddress = row["adres_email"].ToString()
                });
            }

            return readers;
        }

        public async Task<int> AddReader(Reader reader)
        {
            return await databaseService.ExecuteNonQuery($"INSERT INTO czytelnicy(imie, nazwisko, data_urodzenia, adres_zamieszkania, numer_telefonu, adres_email) VALUES('{reader.Name}', '{reader.Surname}', '{reader.Birthdate}', '{reader.Address}', '{reader.Number}', '{reader.EmailAddress}');");
        }
    }
}
