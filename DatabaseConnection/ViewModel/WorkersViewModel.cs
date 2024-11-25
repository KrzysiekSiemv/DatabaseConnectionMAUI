using DatabaseConnection.Model;
using DatabaseConnection.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DatabaseConnection.ViewModel
{
    public class WorkersViewModel : INotifyPropertyChanged
    {
        private readonly WorkerService _workerService;

        public ObservableCollection<Worker> Workers { get; set; } = [];

        public WorkersViewModel(WorkerService workerService)
        {
            _workerService = workerService;
            LoadWorkersCommand = new Command(async () => await LoadWorkers());
        }

        public Command LoadWorkersCommand { get; }

        private async Task LoadWorkers()
        {
            Workers.Clear();
            var workers = await _workerService.GetWorkers();
            foreach (var worker in workers)
            {
                Workers.Add(worker);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
