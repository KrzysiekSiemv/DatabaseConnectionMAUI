namespace DatabaseConnection.Model
{
    public class Worker
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname {  get; set; }
        public string? StartOfWorking {  get; set; }
        public string? Position {  get; set; }
        public double HourlyRate { get; set; }
        public string? EndOfWorking { get; set; }
    }
}
