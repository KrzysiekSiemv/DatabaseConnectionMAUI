using DatabaseConnection.View;

namespace DatabaseConnection
{
    public partial class MainPage : TabbedPage
    {
        public MainPage(AuthorsPage ap, BooksPage bp, ReadersPage rp, WorkersPage wp)
        {
            InitializeComponent();

            Children.Add(ap);
            Children.Add(bp);
            Children.Add(rp);
            Children.Add(wp);
        }
    }

}
