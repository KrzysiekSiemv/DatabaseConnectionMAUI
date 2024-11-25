using DatabaseConnection.Model;
using DatabaseConnection.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DatabaseConnection.ViewModel
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private readonly BookService _bookService;

        public ObservableCollection<Book> Books { get; set; } = [];

        public BookViewModel(BookService bookService)
        {
            _bookService = bookService;
            LoadBooksCommand = new Command(async () => await LoadBooks());
        }

        public Command LoadBooksCommand { get; }

        private async Task LoadBooks()
        {
            Books.Clear();
            var books = await _bookService.GetBooks();
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
