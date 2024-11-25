using DatabaseConnection.Services;
using DatabaseConnection.View;
using DatabaseConnection.ViewModel;
using Microsoft.Extensions.Logging;

namespace DatabaseConnection
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            DatabaseService dbService = new();

            builder.Services.AddSingleton<DatabaseService>(sp => new DatabaseService());
            builder.Services.AddSingleton<AuthorService>();
            builder.Services.AddSingleton<AuthorsViewModel>();
            builder.Services.AddSingleton<AuthorsPage>();
            builder.Services.AddSingleton<BookService>();
            builder.Services.AddSingleton<BookViewModel>();
            builder.Services.AddSingleton<BooksPage>();
            builder.Services.AddSingleton<ReaderService>();
            builder.Services.AddSingleton<ReadersViewModel>();
            builder.Services.AddSingleton<ReadersPage>();
            builder.Services.AddSingleton<WorkerService>();
            builder.Services.AddSingleton<WorkersViewModel>();
            builder.Services.AddSingleton<WorkersPage>();
            builder.Services.AddSingleton<MainPage>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
