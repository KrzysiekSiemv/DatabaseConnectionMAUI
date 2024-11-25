namespace DatabaseConnection.Model
{
    public class Reader
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Address { get; set; }
        public string? Birthdate { get; set; }
        public long Number { get; set; }
        public string? EmailAddress { get; set; }
        public Book[] RentedBooks { get; set; }

        public Reader()
        {
            RentedBooks = [];
        }
    }
}
