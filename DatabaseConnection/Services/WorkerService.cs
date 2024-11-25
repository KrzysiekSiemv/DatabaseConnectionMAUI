using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DatabaseConnection.Model;

namespace DatabaseConnection.Services
{
    public class WorkerService
    {
        private readonly DatabaseService databaseService;

        public WorkerService(DatabaseService databaseService) => this.databaseService = databaseService;

        public async Task<List<Worker>> GetWorkers()
        {
            List<Worker> workers = [];

            var table = await databaseService.ExecuteQuery("SELECT * FROM pracownicy");
            foreach (DataRow row in table.Rows)
            {
                workers.Add(new Worker
                {
                    Id = Convert.ToInt32(row["id_autor"]),
                    Name = row["imie"].ToString(),
                    Surname = row["nazwisko"].ToString(),
                    StartOfWorking = row["data_rozpoczecia_pracy"].ToString(),
                    Position = row["stanowisko"].ToString(),
                    HourlyRate = Convert.ToDouble(row["stawka_godzinowa"]),
                    EndOfWorking = row["data_zakonczenia_pracy"].ToString()
                });
            }

            return workers;
        }
    }
}
