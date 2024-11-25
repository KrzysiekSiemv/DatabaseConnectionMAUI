using DatabaseConnection.Services;

namespace DatabaseConnection
{
    public partial class App : Application
    {
        public App(MainPage main)
        {
            InitializeComponent();

            MainPage = main;
        }
    }
}
