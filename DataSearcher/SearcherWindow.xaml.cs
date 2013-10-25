using System.Windows;

namespace DataSearcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SearcherWindow : Window
    {
        public SearcherWindow()
        {
            InitializeComponent();
            this.DataContext = new SearcherWindowViewModel();
        }
    }
}
