using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DatabaseConnection.Model;

namespace DatabaseConnection.Services
{
    public class BookService
    {
        private readonly DatabaseService databaseService;

        public BookService(DatabaseService databaseService) => this.databaseService = databaseService;

        public async Task<List<Book>> GetBooks()
        {
            List<Book> books = [];

            var table = await databaseService.ExecuteQuery("SELECT id_ksiazka, tytul, GROUP_CONCAT(imie, ' ', nazwisko) as autor, kategoria.nazwa, wydawca, data_publikacji, cena, ilosc FROM ksiazki, autorzy_ksiazek, kategoria WHERE ksiazki.id_kategoria = kategoria.id_kategoria AND ksiazki.id_autor = autorzy_ksiazek.id_autor GROUP BY tytul");
            foreach (DataRow row in table.Rows)
            {
                books.Add(new Book
                {
                    Id = Convert.ToInt32(row["id_ksiazka"]),
                    Title = row["tytul"].ToString(),
                    Author = row["autor"].ToString(),
                    Category = row["nazwa"].ToString(),
                    Publisher = row["wydawca"].ToString(),
                    PublishDate = row["data_publikacji"].ToString(),
                    Price = Convert.ToDouble(row["cena"]),
                    Amount = Convert.ToInt32(row["ilosc"])
                });
            }

            return books;
        }
    }
}
