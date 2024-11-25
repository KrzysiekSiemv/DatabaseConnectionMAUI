using DatabaseConnection.Model;
using DatabaseConnection.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DatabaseConnection.ViewModel
{
    public partial class AuthorsViewModel : INotifyPropertyChanged
    {
        private readonly AuthorService _authorService;

        public ObservableCollection<Author> Authors { get; set; } = [];

        public AuthorsViewModel(AuthorService authorService)
        {
            _authorService = authorService;
            LoadAuthorsCommand = new Command(async () => await LoadAuthors());
        }

        public Command LoadAuthorsCommand { get; }

        private async Task LoadAuthors()
        {
            Authors.Clear();
            var authors = await _authorService.GetAuthors();
            foreach (var author in authors)
            {
                Authors.Add(author);
            }
            OnPropertyChanged(nameof(Authors));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
