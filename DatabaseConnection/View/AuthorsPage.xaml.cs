using DatabaseConnection.ViewModel;

namespace DatabaseConnection.View;

public partial class AuthorsPage : ContentPage
{
	public AuthorsPage(AuthorsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}