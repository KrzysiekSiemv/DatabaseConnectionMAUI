using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DatabaseConnection.Model;

namespace DatabaseConnection.Services
{
    public partial class AuthorService
    {
        private readonly DatabaseService databaseService;

        public AuthorService(DatabaseService databaseService) => this.databaseService = databaseService;

        public async Task<List<Author>> GetAuthors()
        {
            List<Author> authors = [];
                var table = await databaseService.ExecuteQuery("SELECT * FROM autorzy_ksiazek");
                foreach (DataRow row in table.Rows)
                {
                    authors.Add(new Author
                    {
                        Id = Convert.ToInt32(row["id_autor"]),
                        Name = row["imie"].ToString(),
                        Surname = row["nazwisko"].ToString(),
                        Birthdate = row["data_urodzenia"].ToString()
                    });

                }
            return authors;
        }

        public async Task<int> AddAuthor(Author author)
        {
            return await databaseService.ExecuteNonQuery($"INSERT INTO autorzy_ksiazek(imie, nazwisko, data_urodzenia) VALUES('{author.Name}', '{author.Surname}', '{author.Birthdate}');");
        }
    }
}
