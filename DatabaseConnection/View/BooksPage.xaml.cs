using DatabaseConnection.ViewModel;

namespace DatabaseConnection.View;

public partial class BooksPage : ContentPage
{
	public BooksPage(BookViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}