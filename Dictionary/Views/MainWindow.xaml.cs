using System.Windows;
using Dictionary.ViewModels;

namespace Dictionary.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GlossaryViewModel _glossaryViewModel;

        public MainWindow(GlossaryViewModel glossaryViewModel)
        {
            _glossaryViewModel = glossaryViewModel;
            DataContext = _glossaryViewModel;
            InitializeComponent();
        }
    }
}
