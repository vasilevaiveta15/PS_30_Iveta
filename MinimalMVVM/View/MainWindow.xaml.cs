using System.Collections.ObjectModel;
using System.Windows;
using MinimalMVVM.ViewModel;

namespace MinimalMVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isUpper = true;
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();
        private readonly Presenter _upperPresenter;
        private readonly Presenter _lowerPresenter;

        public MainWindow()
        {
            DataContext = _upperPresenter = new ToUpperPresenter(_history);
            _lowerPresenter = new ToLowerPresenter(_history);
            InitializeComponent();
        }

        private void SwitchCase(object sender, RoutedEventArgs e)
        {
            var prevText = ((Presenter)DataContext).SomeText;
            _isUpper = !_isUpper;
            DataContext = _isUpper ? _upperPresenter : _lowerPresenter;
            ((Presenter)DataContext).SomeText = prevText;
        }
    }
}