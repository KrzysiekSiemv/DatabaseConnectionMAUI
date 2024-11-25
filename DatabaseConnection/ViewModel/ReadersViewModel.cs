using DatabaseConnection.Model;
using DatabaseConnection.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DatabaseConnection.ViewModel
{
    public class ReadersViewModel : INotifyPropertyChanged
    {
        private readonly ReaderService _readerService;

        public ObservableCollection<Reader> Readers { get; set; } = [];

        public ReadersViewModel(ReaderService readerService)
        {
            _readerService = readerService;
            LoadReadersCommand = new Command(async () => await LoadReaders());
        }

        public Command LoadReadersCommand { get; }

        private async Task LoadReaders()
        {
            Readers.Clear();
            var readers = await _readerService.GetReaders();
            foreach (var reader in readers)
            {
                Readers.Add(reader);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
